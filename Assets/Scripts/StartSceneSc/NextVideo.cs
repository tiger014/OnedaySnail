using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NextVideo : MonoBehaviour
{
    public GameObject StoryShowCanvas;

    public GameObject PostProcess;
    public GameObject VideoPlaneOP2;
    public GameObject VideoPlaneOP1;
    float a;

    void Start()
    {
        //�p�l�����B��
        StoryShowCanvas.SetActive(false);
    }
    private void Update()
    {
        if (a == 0)
        {
            PostProcess.SetActive(false);
            VideoPlaneOP1.SetActive(true);
            VideoPlaneOP2.SetActive(false);
        }
        else if (a == 1)
        {
            VideoPlaneOP1.SetActive(false);
            VideoPlaneOP2.SetActive(true);
        }

    }
    public void OnClickStart()
    {
        //Debug.Log("�����ꂽ!");  // ���O���o��
        a += 1;
    }
}
