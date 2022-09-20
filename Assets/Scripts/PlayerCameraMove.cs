using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class PlayerCameraMove : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera ObVirtualCamera2;
    [SerializeField] private GameObject ObVirtualCamera;//上と同じオブジェクト

    [SerializeField] private GameObject AdModeIcon;
    [SerializeField] private GameObject ObModeIcon;
    [SerializeField] private GameObject ObCameraCube;
    [SerializeField] private GameObject CameraLookCube;


    private CinemachineTrackedDolly stdolly;

    public bool ObMode;

    private float obposition;       //パスポジション

    void Start()
    {
        ObMode = false;

        // Virtual Cameraに対してGetCinemachineComponentでCinemachineTrackedDollyを取得する
        // GetComponentではなくGetCinemachineComponentなので注意
        stdolly = ObVirtualCamera2.GetCinemachineComponent<CinemachineTrackedDolly>();
    }

    void Update()
    {
        //モードの切り替え (3秒たったら操作可能になる)
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
        //STカメラをアクティブにする
        ObVirtualCamera.SetActive(true);
        ObModeIcon.SetActive(true);
        ObCameraCube.SetActive(true);
        AdModeIcon.SetActive(false);

        //CameraLookCube.SetActive(false);

    }

    void SnailFollowMode()
    {
        //Debug.Log("変わったぜ");
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