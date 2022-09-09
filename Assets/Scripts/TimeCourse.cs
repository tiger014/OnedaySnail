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
    public float sunset;
    public float night;
    public bool onevening;
    public bool onsunset;
    public bool onnight;

    float Lred;
    float Lgre;
    float Lble;

    float lint;
    float evegre;
    float eveble;
    float nigred;
    float niggre;
    float nigble;

    void Start()
    {
        //Application.targetFrameRate = 60;

        floowStart = true;
        timeofday = Timer.gameTime;         //ゲーム時間

        sunset = timeofday / 2;             //日没
        evening = sunset - timeofday / 6;   //夕焼け
        night = sunset + timeofday / 6;     //夜

        direx = 30f;                        //始まったときの角度
        float x = 50 / timeofday;
        Direspeed = x / 60;

        LIntensity = DireLight.GetComponent<Light>().intensity;
        LColor = DireLight.GetComponent<Light>().color;
        LIntensity = 1.3f;
        Lred = 1f;
        Lgre = 1f;
        Lble = 0.8f;

        float q = 1.2f / timeofday;         //それぞれの移行時間
        lint = q / 6;

        float a = 0.3f / timeofday;
        evegre = a / 6;
        float b = 0.2f / timeofday;
        eveble = b / 6;
        float c = 0.5f / timeofday;
        nigred = b / 6;
        float d = 0.3f / timeofday;
        niggre = b / 6;
        float e = 0.4f / timeofday;
        nigble = b / 6;


    }
    void Update()
    {
        LColor = new Color(Lred, Lgre, Lble);
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
        else if (timefloow >= sunset)    //夕方
        {
            onsunset = true;
        }
        else if (timefloow >= evening)
        {
            onevening = true;
        }

        if(onevening)
        {
            Debug.Log("夕焼け始");
            Lgre -= evegre;
            Lble -= eveble;
            if (Lgre <= 0.7f)
            {
                Lgre = 0.7f;
            }
            if (Lble <= 0.6f)
            {
                Lble = 0.6f;
            }
        }
        if(onsunset)
        {
            Debug.Log("夕方");
            onevening = false;
            LColor = new Color(1f, 0.7f, 0.6f);
            LColor = new Color(0.5f, 1f, 1f);
            Lred -= nigred;
            Lgre += niggre;
            Lble += nigble;
            if (Lred <= 0.5f)
            {
                Lred = 0.5f;
            }
            if (Lgre >= 1f)
            {
                Lgre = 1f;
            }
            if (Lble >= 1f)
            {
                Lble = 1f;
            }






            LIntensity -= lint;
            if(LIntensity <= 0.1f)
            {
                LIntensity = 0.1f;
            }
        }
        if (onnight)
        {
            Debug.Log("夜");
            onsunset = false;
            LIntensity = 0.1f;
        }
    }
}
