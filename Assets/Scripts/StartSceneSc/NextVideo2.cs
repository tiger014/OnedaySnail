using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NextVideo2 : MonoBehaviour
{
    public bool OnClick = false;
    public GameObject VideoPlaneOP2;
    public GameObject ImageOP3;
    private void Update()
    {

        if (OnClick == true)
        {
            VideoPlaneOP2.SetActive(false);
            ImageOP3.SetActive(true);
        }
        else
        {
            ImageOP3.SetActive(false);
        }
    }

    public void OnClickStart()
    {
        //Debug.Log("âüÇ≥ÇÍÇΩ!");  // ÉçÉOÇèoóÕ
        OnClick = true;
    }
}
