using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class PlayerCameraMove : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera ObVirtualCamera2;
    [SerializeField] private GameObject ObVirtualCamera;//��Ɠ����I�u�W�F�N�g

    [SerializeField] private GameObject SFModeIcon;
    [SerializeField] private GameObject ObModeIcon;
    [SerializeField] private GameObject CameraLookCube;


    private CinemachineTrackedDolly stdolly;

    public bool ObMode;

    private float obposition;       //�p�X�|�W�V����

    public float currentTime = 0f;

    void Start()
    {
        ObMode = true;

        // Virtual Camera�ɑ΂���GetCinemachineComponent��CinemachineTrackedDolly���擾����
        // GetComponent�ł͂Ȃ�GetCinemachineComponent�Ȃ̂Œ���
        stdolly = ObVirtualCamera2.GetCinemachineComponent<CinemachineTrackedDolly>();
    }

    void Update()
    {
        currentTime += Time.deltaTime;

        //���[�h�̐؂�ւ� (3�b�������瑀��\�ɂȂ�)
        if (ObMode == true)
        {
            //ST�J�������A�N�e�B�u�ɂ���
            ObVirtualCamera.SetActive(true);
            ObModeIcon.SetActive(true);
            SFModeIcon.SetActive(false);

            //CameraLookCube.SetActive(false);

            if (currentTime >= 3)
            {
                ObservationMode();
            }
        }
        else
        {
            ObVirtualCamera.SetActive(false);
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
    }

    void SnailFollowMode()
    {
        //Debug.Log("�ς������");
        //CameraLookCube.SetActive(true);
        currentTime = 3f;

        if (Input.GetKeyDown(KeyCode.Space) || (OVRInput.GetDown(OVRInput.RawButton.RHandTrigger)))
        {
            ObMode = true;

            currentTime = 0f;
        }
    }
}