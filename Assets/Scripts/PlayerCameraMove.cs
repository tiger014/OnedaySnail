using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class PlayerCameraMove : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera ObVirtualCamera2;
    [SerializeField] private GameObject ObVirtualCamera;//��Ɠ����I�u�W�F�N�g

    [SerializeField] private GameObject AdModeIcon;
    [SerializeField] private GameObject ObModeIcon;
    [SerializeField] private GameObject ObCameraCube;
    [SerializeField] private GameObject CameraLookCube;


    private CinemachineTrackedDolly stdolly;

    public bool ObMode;

    private float obposition;       //�p�X�|�W�V����

    void Start()
    {
        ObMode = false;

        // Virtual Camera�ɑ΂���GetCinemachineComponent��CinemachineTrackedDolly���擾����
        // GetComponent�ł͂Ȃ�GetCinemachineComponent�Ȃ̂Œ���
        stdolly = ObVirtualCamera2.GetCinemachineComponent<CinemachineTrackedDolly>();
    }

    void Update()
    {
        //���[�h�̐؂�ւ� (3�b�������瑀��\�ɂȂ�)
        if (ObMode == true)
        {
            ObservationMode();
        }
        else
        {
            SnailFollowMode();
        }
    }

    void ObservationMode()
    {
        if (Input.GetKeyDown(KeyCode.Space) || OVRInput.GetDown(OVRInput.RawButton.LIndexTrigger))
        {
            ObMode = false;
        }
        //ST�J�������A�N�e�B�u�ɂ���
        ObVirtualCamera.SetActive(true);
        ObModeIcon.SetActive(true);
        ObCameraCube.SetActive(true);
        AdModeIcon.SetActive(false);

        //CameraLookCube.SetActive(false);

    }

    void SnailFollowMode()
    {
        //Debug.Log("�ς������");
        //CameraLookCube.SetActive(true);
        if (Input.GetKeyDown(KeyCode.Space) || OVRInput.GetDown(OVRInput.RawButton.LIndexTrigger))
        {
            ObMode = true;
        }
        ObVirtualCamera.SetActive(false);
        ObModeIcon.SetActive(false);
        ObCameraCube.SetActive(false);
        AdModeIcon.SetActive(true);
    }
}