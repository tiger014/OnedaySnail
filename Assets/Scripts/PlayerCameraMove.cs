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

    private CinemachineTrackedDolly stdolly;

    public bool ObMode;
    public float obspeed = 1f;      //移動速度
    public Vector2 stickR;          //アナログスティック
    private float obposition;       //パスポジション

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

        //モードの切り替え
        if (ObMode == true)
        {
            //STカメラをアクティブにする
            ObVirtualCamera2.SetActive(true);
            ObModeIcon.SetActive(true);
            SFModeIcon.SetActive(false);

            if (Input.GetKeyDown(KeyCode.Space)||(OVRInput.GetDown(OVRInput.RawButton.RHandTrigger)))
            {
                ObMode = false;
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
        else
        {
            ObVirtualCamera2.SetActive(false);
            ObModeIcon.SetActive(false);
            SFModeIcon.SetActive(true);

            if (Input.GetKeyDown(KeyCode.Space)||(OVRInput.GetDown(OVRInput.RawButton.RHandTrigger)))
            {
                ObMode = true;
            }
        }

    }
}