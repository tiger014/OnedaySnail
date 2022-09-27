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
    public GameObject NextButtonOp1;
    float a;
    float buttonspeed = 0;

    void Start()
    {
        //パネルを隠す
        StoryShowCanvas.SetActive(false);
    }
    private void Update()
    {
        buttonspeed += Time.deltaTime;
        if (buttonspeed >= 20f)
        {
            NextButtonOp1.SetActive(true);
            buttonspeed = 20f;
        }

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
        //Debug.Log("押された!");  // ログを出力
        a += 1;
    }
}
