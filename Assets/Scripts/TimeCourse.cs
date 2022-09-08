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
    float direx;//�p�x

    public float timeofday;     //����̎���
    public float timefloow;     //���Ԍo��

    public float evening;
    bool onevening;
    public float night;
    bool onnight;

    void Start()
    {
        //Application.targetFrameRate = 60;

        floowStart = true;
        timeofday = Timer.gameTime;         //�Q�[������

        evening = timeofday / 2;            //�[��
        night = evening + timeofday / 6;    //��

        direx = 30f;                        //�n�܂����Ƃ��̊p�x
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
        Transform dirTransform = DireLight.transform;   //�f�B���N�V���i�����C�g�̊p�x�̎擾
        Vector3 worldAngle = dirTransform.eulerAngles;
        worldAngle.x = direx;
        worldAngle.y = 54f;
        worldAngle.z = 0f;
        dirTransform.eulerAngles = worldAngle;
        DireLight.GetComponent<Light>().intensity = LIntensity;    //���C�g�̌���
        DireLight.GetComponent<Light>().color = LColor;

        if (timefloow >= timeofday)      //����̏I���
        {

        }
        else if (timefloow >= night)     //��
        {
            onnight = true;
        }
        else if (timefloow >= evening)    //�[��
        {
            onevening = true;
        }

        if(onevening)
        {
            Debug.Log("�[��");
            LIntensity -= 0.002f;
            if(LIntensity <= 0.1f)
            {
                LIntensity = 0.1f;
            }
        }
        if (onnight)
        {
            Debug.Log("��");
        }
    }
}
