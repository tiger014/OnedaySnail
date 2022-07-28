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
    public float obspeed = 1f;      //移動速度

    public Vector3 Obt;             //Obのトランスフォーム
    public Vector2 stickR;          //アナログスティック
    float Obtx;
    float Obtz;

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
        //stickR = OVRInput.Get(OVRInput.RawAxis2D.RThumbstick);//右スティック
        //ObVirtualCamera.GetComponent<Transform>();//観察モードのトランスフォーム
        //Transform Obtransform = ObVirtualCamera.transform;
        //Obtransform.localPosition = Obt;//Obtに反映させる

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

        //移動させる
        //Obt = new Vector3(Obtx , 9 , Obtz);

        //Obtx += stickR.x * obspeed * Time.deltaTime;
        //Obtz += stickR.y * obspeed * Time.deltaTime;
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