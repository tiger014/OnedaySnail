using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class TimeCourse : MonoBehaviour
{
    public bool floowStart;

    public GameObject DireLight;
    float LIntensity;
    Color LColor;
    public GameObject MoonLight;
    float MIntensity;
    Color FogColor;

    public PostProcessVolume PostProcessing;
    ColorGrading _colorGrading;
    float temp;
    float tint;

    public float Direspeed;
    float direx;//�p�x

    public float timeofday;     //����̎���
    public float timefloow;     //���Ԍo��

    public float evening;
    public float sunset;
    public float night;
    public bool onevening;
    public bool onsunset;
    public bool onnight;

    float Lred;
    float Lgre;
    float Lble;

    float Fred;
    float Fgre;
    float Fble;

    float Pred;
    float Pgre;
    float Pble;

    float lint;
    float mint;
    float evegre;
    float eveble;
    float nigred;
    float niggre;
    float nigble;

    float fogever;
    float fogeveb;

    float temeve;
    float tineve;
    float temnig;
    float tinnig;

    float pblenig;
    float mtz;

    void Start()
    {
        //Application.targetFrameRate = 60;

        floowStart = true;
        timeofday = Timer.gameTime;         //�Q�[������

        sunset = timeofday / 2;             //���v
        evening = sunset - timeofday / 6;   //�[�Ă�
        night = sunset + timeofday / 6;     //��

        direx = 30f;                        //�n�܂����Ƃ��̊p�x
        float x = 50 / timeofday;
        Direspeed = x / 60;
        mtz = 0.0f;

        PostProcessing.GetComponent<PostProcessVolume>();//�|�X�g�v���Z�X
        foreach (PostProcessEffectSettings item in PostProcessing.profile.settings)
        {
            if (item as ColorGrading)
            {
                _colorGrading = item as ColorGrading;
            }
        }
        temp = 20f;
        tint = 36f;
        Pred = 0.9f;
        Pgre = 0.9f;
        Pble = 0.7f;

        LIntensity = DireLight.GetComponent<Light>().intensity;
        LColor = DireLight.GetComponent<Light>().color;
        LIntensity = 1.3f;
        Lred = 1f;
        Lgre = 1f;
        Lble = 0.8f;

        MIntensity = MoonLight.GetComponent<Light>().intensity;
        MIntensity = 0.0f;

        Fred = 0.4f;    //FogColor
        Fgre = 1.0f;
        Fble = 0.83f;

        float q = 1.2f / timeofday;         //���ꂼ��̈ڍs����
        lint = q / 6;
        float p = 10.0f / timeofday;
        mint = p / 6;

        float a = 0.3f / timeofday;
        evegre = a / 6;
        float b = 0.2f / timeofday;
        eveble = b / 6;
        float c = 0.5f / timeofday;
        nigred = c / 6;
        float d = 0.3f / timeofday;
        niggre = d / 6;
        float e = 0.4f / timeofday;
        nigble = e / 6;

        float f = 0.1f / timeofday;
        fogever = f / 6;
        float h = 0.07f / timeofday;
        fogeveb = h / 6;

        float i = 30f / timeofday;
        temeve = i / 6;
        float j = 4f / timeofday;
        tineve = j / 6;
        float k = 55f / timeofday;
        temnig = k / 6;
        float l = 60f / timeofday;
        tinnig = l / 6;

        float m = 0.1f / timeofday;
        pblenig = m / 6;
    }
    void Update()
    {
        LColor = new Color(Lred, Lgre, Lble);
        FogColor = new Color(Fred, Fgre, Fble);
        RenderSettings.fogColor = FogColor;

        if (floowStart)
        {
            timefloow += Time.deltaTime;
            direx += Direspeed;
        }
        if (_colorGrading)//�|�X�g�G�t�F�N�g�̃p�����[�^�ɒl��������
        {
            _colorGrading.temperature.value = temp;
            _colorGrading.tint.value = tint;
            _colorGrading.colorFilter.value = new Color(Pred, Pgre, Pble);
        }
        Transform dirTransform = DireLight.transform;   //�f�B���N�V���i�����C�g�̊p�x�̎擾
        Vector3 worldAngle = dirTransform.eulerAngles;
        worldAngle.x = direx;
        worldAngle.y = 54f;
        worldAngle.z = 0f;
        dirTransform.eulerAngles = worldAngle;
        DireLight.GetComponent<Light>().intensity = LIntensity;    //���C�g�̌���
        DireLight.GetComponent<Light>().color = LColor;
        MoonLight.GetComponent<Light>().intensity = MIntensity;
        MoonLight.transform.rotation = Quaternion.Euler(90f, 0.0f, mtz);

        if (timefloow >= timeofday)      //����̏I���
        {
        }
        else if (timefloow >= night)     //��
        {
            onnight = true;
        }
        else if (timefloow >= sunset)    //�[��
        {
            onsunset = true;
        }
        else if (timefloow >= evening)
        {
            onevening = true;
        }

        if(onevening)
        {
            //Debug.Log("�[�Ă��n");
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
            Fred -= fogever;
            Fgre -= nigble;
            Fble += fogeveb;
            if (Fred <= 0.3f)
            {
                Fred = 0.3f;
            }
            if (Fgre <= 0.6f)
            {
                Fgre = 0.6f;
            }
            if (Fble >= 0.9f)
            {
                Fble = 0.9f;
            }
            temp += temeve;
            tint += tineve;
            if (temp >= 50f)
            {
                temp = 50f;
            }
            if (tint >= 40f)
            {
                tint = 40f;
            }
        }
        if(onsunset)
        {
            //Debug.Log("�[��");
            onevening = false;
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
            Fble -= eveble;
            if (Fble <= 0.7f)
            {
                Fble = 0.7f;
            }
            temp -= temnig;
            tint -= tinnig;
            if (temp <= -5f)
            {
                temp = -5f;
            }
            if (tint <= -20f)
            {
                tint = -20f;
            }
            Pred -= nigred;
            Pgre -= eveble;
            Pble += pblenig;
            if (Pred <= 0.4f)
            {
                Pred = 0.4f;
            }
            if (Pgre <= 0.7f)
            {
                Pgre = 0.7f;
            }
            if (Pble >= 0.8f)
            {
                Pble = 0.8f;
            }
            LIntensity -= lint;
            if (LIntensity <= 0.1f)
            {
                LIntensity = 0.1f;
            }
            MIntensity += mint;
            if (MIntensity >= 10.0f)
            {
                MIntensity = 10.0f;
            }
            mtz += 0.01f;
        }
        if (onnight)
        {
            //Debug.Log("��");
            onsunset = false;
            LIntensity = 0.1f;
            MIntensity = 10.0f;
            mtz += 0.01f;
        }
    }
}
