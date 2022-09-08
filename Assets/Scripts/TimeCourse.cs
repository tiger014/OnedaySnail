using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeCourse : MonoBehaviour
{
    public bool floowStart;

    public GameObject DireLight;
    float LIntensity;
    Color LColor;

    public float Direspeed;
    float direx;//角度

    public float timeofday;     //一日の時間
    public float timefloow;     //時間経過

    public float evening;
    bool onevening;
    public float night;
    bool onnight;

    void Start()
    {
        //Application.targetFrameRate = 60;

        floowStart = true;
        timeofday = Timer.gameTime;         //ゲーム時間

        evening = timeofday / 2;            //夕方
        night = evening + timeofday / 6;    //夜

        direx = 30f;                        //始まったときの角度
        float x = 50 / timeofday;
        Direspeed = x / 60;

        LIntensity = DireLight.GetComponent<Light>().intensity;
        LColor = DireLight.GetComponent<Light>().color;
        LIntensity = 1.3f;
        LColor = new Color(1f, 1f, 0.8f);


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
        DireLight.GetComponent<Light>().intensity = LIntensity;    //ライトの光量
        DireLight.GetComponent<Light>().color = LColor;

        if (timefloow >= timeofday)      //一日の終わり
        {

        }
        else if (timefloow >= night)     //夜
        {
            onnight = true;
        }
        else if (timefloow >= evening)    //夕方
        {
            onevening = true;
        }

        if(onevening)
        {
            Debug.Log("夕方");
            LIntensity -= 0.002f;
            if(LIntensity <= 0.1f)
            {
                LIntensity = 0.1f;
            }
        }
        if (onnight)
        {
            Debug.Log("夜");
        }
    }
}
