using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeCourse : MonoBehaviour
{
    public bool floowStart;

    public GameObject DireLight;
    float x;
    public float Direspeed;
    float direx;//角度

    public float timeofday;     //一日の時間
    public float timefloow;     //時間経過

    public float evening;
    public float night;

    void Start()
    {
        //Application.targetFrameRate = 60;

        floowStart = true;
        timeofday = Timer.gameTime;         //ゲーム時間

        evening = timeofday / 2;            //夕方
        night = evening + timeofday / 6;    //夜

        direx = 30f;

        x = 50 / timeofday;

        Direspeed = x / 60;




    }
    void Update()
    {


        if (floowStart)
        {
            timefloow += Time.deltaTime;


            direx += Direspeed;


        }
        Transform dirTransform = DireLight.transform;   //ディレクショナルライトの角度の取得
        Vector3 worldAngle = dirTransform.eulerAngles;
        worldAngle.x = direx;
        worldAngle.y = 54f;
        worldAngle.z = 0f;
        dirTransform.eulerAngles = worldAngle;


        if (timefloow >= timeofday)      //一日の終わり
        {

        }
        else if (timefloow >= night)     //夜
        {
            Debug.Log("夜");
        }
        else if (timefloow >= evening)    //夕方
        {
            Debug.Log("夕方");
        }



    }
}
