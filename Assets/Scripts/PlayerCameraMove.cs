using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class PlayerCameraMove : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera ObVirtualCamera;
    [SerializeField] private GameObject ObVirtualCamera2;//上と同じオブジェクト

    [SerializeField] private GameObject SFModeIcon;
    [SerializeField] private GameObject ObModeIcon;
    [SerializeField] private GameObject CameraLookCube;

    private CinemachineTrackedDolly stdolly;

    public bool ObMode;
    public float obspeed = 1f;      //移動速度
    public Vector2 stickR;          //アナログスティック
    private float obposition;       //パスポジション

    public float currentTime = 0f;

    void Start()
    {
        ObMode = false;

        // Virtual Cameraに対してGetCinemachineComponentでCinemachineTrackedDollyを取得する
        // GetComponentではなくGetCinemachineComponentなので注意
        stdolly = ObVirtualCamera.GetCinemachineComponent<CinemachineTrackedDolly>();
    }

    void Update()
    {
        stickR = OVRInput.Get(OVRInput.RawAxis2D.RThumbstick);//右スティック

        currentTime += Time.deltaTime;

        //モードの切り替え (3秒たったら操作可能になる)
        if (ObMode == true)
        {
            //STカメラをアクティブにする
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

        //STModeの時の操作
        if (stickR.x < 0)
        {
            // パスの位置を更新する
            stdolly.m_PathPosition += obspeed * Time.deltaTime;
        }
        if (stickR.x > 0)
        {
            // パスの位置を更新する
            stdolly.m_PathPosition -= obspeed * Time.deltaTime;
        }
    }

    void SnailFollowMode()
    {
        //Debug.Log("変わったぜ");
        CameraLookCube.SetActive(true);
        currentTime = 3f;

        if (Input.GetKeyDown(KeyCode.Space) || (OVRInput.GetDown(OVRInput.RawButton.RHandTrigger)))
        {
            ObMode = true;

            currentTime = 0f;
        }
    }
}