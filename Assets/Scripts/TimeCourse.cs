using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeCourse : MonoBehaviour
{
    public bool floowStart;

    public GameObject DireLight;
    float x;
    public float Direspeed;
    float direx;//�p�x

    public float timeofday;     //����̎���
    public float timefloow;     //���Ԍo��

    public float evening;
    public float night;

    void Start()
    {
        //Application.targetFrameRate = 60;

        floowStart = true;
        timeofday = Timer.gameTime;         //�Q�[������

        evening = timeofday / 2;            //�[��
        night = evening + timeofday / 6;    //��

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
        Transform dirTransform = DireLight.transform;   //�f�B���N�V���i�����C�g�̊p�x�̎擾
        Vector3 worldAngle = dirTransform.eulerAngles;
        worldAngle.x = direx;
        worldAngle.y = 54f;
        worldAngle.z = 0f;
        dirTransform.eulerAngles = worldAngle;


        if (timefloow >= timeofday)      //����̏I���
        {

        }
        else if (timefloow >= night)     //��
        {
            Debug.Log("��");
        }
        else if (timefloow >= evening)    //�[��
        {
            Debug.Log("�[��");
        }



    }
}
