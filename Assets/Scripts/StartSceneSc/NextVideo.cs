using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NextVideo : MonoBehaviour
{
    public bool OnClick = false;
    public GameObject StoryShowCanvas;

    public GameObject PostProcess;
    public GameObject VideoPlaneOP2;
    public GameObject VideoPlaneOP1;


    void Start()
    {
        //パネルを隠す
        StoryShowCanvas.SetActive(false);
    }
    private void Update()
    {

        PostProcess.SetActive(false);
        if (OnClick == true)
        {
            VideoPlaneOP1.SetActive(false);
            VideoPlaneOP2.SetActive(true);
        }
        else
        {
            VideoPlaneOP1.SetActive(true);
            VideoPlaneOP2.SetActive(false);
        }
    }

    public void OnClickStart()
    {
        //Debug.Log("押された!");  // ログを出力
        OnClick = true;
    }
}
