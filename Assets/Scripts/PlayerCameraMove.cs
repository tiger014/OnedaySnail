using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class PlayerCameraMove : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera STVirtualCamera;
    [SerializeField] private GameObject STVirtualCamera2;//上と同じオブジェクト

    private CinemachineTrackedDolly stdolly;

    public bool STMode;
    public float stspeed = 1f;   //移動速度
    public Vector2 stickR;          //アナログスティック
    private float stposition;       //パスポジション

    void Start()
    {
        STMode = false;

        // Virtual Cameraに対してGetCinemachineComponentでCinemachineTrackedDollyを取得する
        // GetComponentではなくGetCinemachineComponentなので注意
        stdolly = STVirtualCamera.GetCinemachineComponent<CinemachineTrackedDolly>();
    }

    void Update()
    {
        stickR = OVRInput.Get(OVRInput.RawAxis2D.RThumbstick);//右スティック

        //モードの切り替え
        if (STMode == true)
        {
            //STカメラをアクティブにする
            STVirtualCamera2.SetActive(true);

            if (Input.GetKeyDown(KeyCode.Space))
            {
                STMode = false;
            }

            //STModeの時の操作
            if (stickR.x < 0)
            {
                // パスの位置を更新する
                stdolly.m_PathPosition += stspeed * Time.deltaTime;
            }
            if (stickR.x > 0)
            {
                // パスの位置を更新する
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