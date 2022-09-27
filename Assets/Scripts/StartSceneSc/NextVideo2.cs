using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NextVideo2 : MonoBehaviour
{
    public bool OnClick = false;
    public GameObject VideoPlaneOP2;
    public GameObject ImageOP3;
    public GameObject NextButtonOp2;
    float buttonspeed = 0;
    private void Update()
    {
        buttonspeed += Time.deltaTime;
        if (buttonspeed >= 15f)
        {
            NextButtonOp2.SetActive(true);
            buttonspeed = 15f;
        }

        if (OnClick == true)
        {
            ImageOP3.SetActive(true);
            VideoPlaneOP2.SetActive(false);
        }
        else
        {
            ImageOP3.SetActive(false);
        }
    }

    public void OnClickStart()
    {
        //Debug.Log("‰Ÿ‚³‚ê‚½!");  // ƒƒO‚ğo—Í
        OnClick = true;
    }
}
