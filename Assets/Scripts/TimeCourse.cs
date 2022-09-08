using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeCourse : MonoBehaviour
{
    public bool floowStart;

    public GameObject DireLight;
    float x;
    public float Direspeed;
    float direx;//Šp“x

    public float timeofday;     //ˆê“ú‚ÌŽžŠÔ
    public float timefloow;     //ŽžŠÔŒo‰ß

    public float evening;
    public float night;

    void Start()
    {
        //Application.targetFrameRate = 60;

        floowStart = true;
        timeofday = Timer.gameTime;         //ƒQ[ƒ€ŽžŠÔ

        evening = timeofday / 2;            //—[•û
        night = evening + timeofday / 6;    //–é

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
        Transform dirTransform = DireLight.transform;   //ƒfƒBƒŒƒNƒVƒ‡ƒiƒ‹ƒ‰ƒCƒg‚ÌŠp“x‚ÌŽæ“¾
        Vector3 worldAngle = dirTransform.eulerAngles;
        worldAngle.x = direx;
        worldAngle.y = 54f;
        worldAngle.z = 0f;
        dirTransform.eulerAngles = worldAngle;


        if (timefloow >= timeofday)      //ˆê“ú‚ÌI‚í‚è
        {

        }
        else if (timefloow >= night)     //–é
        {
            Debug.Log("–é");
        }
        else if (timefloow >= evening)    //—[•û
        {
            Debug.Log("—[•û");
        }



    }
}
