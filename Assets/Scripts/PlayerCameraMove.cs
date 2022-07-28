using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class PlayerCameraMove : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera ObVirtualCamera2;
    [SerializeField] private GameObject ObVirtualCamera;//上と同じオブジェクト

    [SerializeField] private GameObject SFModeIcon;
    [SerializeField] private GameObject ObModeIcon;
    [SerializeField] private GameObject CameraLookCube;


    private CinemachineTrackedDolly stdolly;

    public bool ObMode;

    private float obposition;       //パスポジション

    public float currentTime = 0f;

    void Start()
    {
        ObMode = true;

        // Virtual Cameraに対してGetCinemachineComponentでCinemachineTrackedDollyを取得する
        // GetComponentではなくGetCinemachineComponentなので注意
        stdolly = ObVirtualCamera2.GetCinemachineComponent<CinemachineTrackedDolly>();
    }

    void Update()
    {
        currentTime += Time.deltaTime;

        //モードの切り替え (3秒たったら操作可能になる)
        if (ObMode == true)
        {
            //STカメラをアクティブにする
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
        //Debug.Log("変わったぜ");
        //CameraLookCube.SetActive(true);
        currentTime = 3f;

        if (Input.GetKeyDown(KeyCode.Space) || (OVRInput.GetDown(OVRInput.RawButton.RHandTrigger)))
        {
            ObMode = true;

            currentTime = 0f;
        }
    }
}