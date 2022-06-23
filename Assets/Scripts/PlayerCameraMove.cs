using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class PlayerCameraMove : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera STVirtualCamera;
    [SerializeField] private GameObject STVirtualCamera2;//��Ɠ����I�u�W�F�N�g

    private CinemachineTrackedDolly stdolly;

    public bool STMode;
    public float stspeed = 1f;   //�ړ����x
    public Vector2 stickR;          //�A�i���O�X�e�B�b�N
    private float stposition;       //�p�X�|�W�V����

    void Start()
    {
        STMode = false;

        // Virtual Camera�ɑ΂���GetCinemachineComponent��CinemachineTrackedDolly���擾����
        // GetComponent�ł͂Ȃ�GetCinemachineComponent�Ȃ̂Œ���
        stdolly = STVirtualCamera.GetCinemachineComponent<CinemachineTrackedDolly>();
    }

    void Update()
    {
        stickR = OVRInput.Get(OVRInput.RawAxis2D.RThumbstick);//�E�X�e�B�b�N

        //���[�h�̐؂�ւ�
        if (STMode == true)
        {
            //ST�J�������A�N�e�B�u�ɂ���
            STVirtualCamera2.SetActive(true);

            if (Input.GetKeyDown(KeyCode.Space))
            {
                STMode = false;
            }

            //STMode�̎��̑���
            if (stickR.x < 0)
            {
                // �p�X�̈ʒu���X�V����
                stdolly.m_PathPosition += stspeed * Time.deltaTime;
            }
            if (stickR.x > 0)
            {
                // �p�X�̈ʒu���X�V����
                stdolly.m_PathPosition -= stspeed * Time.deltaTime;
            }
        }
        else
        {
            STVirtualCamera2.SetActive(false);

            if (Input.GetKeyDown(KeyCode.Space))
            {
                STMode = true;
            }
        }

    }
}