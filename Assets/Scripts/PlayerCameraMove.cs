using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class PlayerCameraMove : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera ObVirtualCamera;
    [SerializeField] private GameObject ObVirtualCamera2;//��Ɠ����I�u�W�F�N�g

    [SerializeField] private GameObject SFModeIcon;
    [SerializeField] private GameObject ObModeIcon;
    [SerializeField] private GameObject CameraLookCube;

    private CinemachineTrackedDolly stdolly;

    public bool ObMode;
    public float obspeed = 1f;      //�ړ����x
    public Vector2 stickR;          //�A�i���O�X�e�B�b�N
    private float obposition;       //�p�X�|�W�V����

    public float currentTime = 0f;

    void Start()
    {
        ObMode = false;

        // Virtual Camera�ɑ΂���GetCinemachineComponent��CinemachineTrackedDolly���擾����
        // GetComponent�ł͂Ȃ�GetCinemachineComponent�Ȃ̂Œ���
        stdolly = ObVirtualCamera.GetCinemachineComponent<CinemachineTrackedDolly>();
    }

    void Update()
    {
        stickR = OVRInput.Get(OVRInput.RawAxis2D.RThumbstick);//�E�X�e�B�b�N

        currentTime += Time.deltaTime;

        //���[�h�̐؂�ւ� (3�b�������瑀��\�ɂȂ�)
        if (ObMode == true)
        {
            //ST�J�������A�N�e�B�u�ɂ���
            ObVirtualCamera2.SetActive(true);
            ObModeIcon.SetActive(true);
            SFModeIcon.SetActive(false);

            CameraLookCube.SetActive(false);

            if (currentTime >= 3)
            {
                ObservationMode();
            }
        }
        else
        {
            ObVirtualCamera2.SetActive(false);
            ObModeIcon.SetActive(false);
            SFModeIcon.SetActive(true);

            if (currentTime >= 3)
            {
                SnailFollowMode();
            }
        }
    }

    void ObservationMode()
    {
        currentTime = 3f;

        if (Input.GetKeyDown(KeyCode.Space) || (OVRInput.GetDown(OVRInput.RawButton.RHandTrigger)))
        {
            ObMode = false;

            currentTime = 0f;
        }

        //STMode�̎��̑���
        if (stickR.x < 0)
        {
            // �p�X�̈ʒu���X�V����
            stdolly.m_PathPosition += obspeed * Time.deltaTime;
        }
        if (stickR.x > 0)
        {
            // �p�X�̈ʒu���X�V����
            stdolly.m_PathPosition -= obspeed * Time.deltaTime;
        }
    }

    void SnailFollowMode()
    {
        //Debug.Log("�ς������");
        CameraLookCube.SetActive(true);
        currentTime = 3f;

        if (Input.GetKeyDown(KeyCode.Space) || (OVRInput.GetDown(OVRInput.RawButton.RHandTrigger)))
        {
            ObMode = true;

            currentTime = 0f;
        }
    }
}