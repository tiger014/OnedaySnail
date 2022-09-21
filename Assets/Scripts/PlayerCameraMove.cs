using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class PlayerCameraMove : MonoBehaviour
{
    [SerializeField] private GameObject ObVirtualCamera;
    [SerializeField] private GameObject ObVirtualCamera2;

    [SerializeField] private GameObject AdModeIcon;
    [SerializeField] private GameObject ObModeIcon;
    [SerializeField] private GameObject ObCameraCube;
    [SerializeField] private GameObject CameraLookCube;

    public bool ObMode;
    void Start()
    {
        ObMode = false;
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
        ObVirtualCamera2.SetActive(true);
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
        ObVirtualCamera2.SetActive(false);
        ObModeIcon.SetActive(false);
        ObCameraCube.SetActive(false);
        AdModeIcon.SetActive(true);
    }
}