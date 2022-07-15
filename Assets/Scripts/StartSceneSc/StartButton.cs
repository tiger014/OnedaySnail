using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartButton : MonoBehaviour
{
    //[SerializeField] private CanvasGroup StartCanvas; //キャンバスグループの取得
    [SerializeField] private GameObject StartCanvas;
    [SerializeField] private GameObject NextCanvas;
    public float Cam_alpha = 1.0f; //キャンバスの不透明度
    public float alspeed = 0.0f;
    public bool OnClick = false;

    private void Update()
    {
        StartCanvas.GetComponent<CanvasGroup>().alpha = Cam_alpha;

        if (OnClick == true)
        {
            Cam_alpha = Cam_alpha - alspeed;
        }

        if (Cam_alpha <= 0.0f)
        {
            Cam_alpha = 0.0f;

            StartCanvas.SetActive(false);
            NextCanvas.SetActive(true);

        }

        
    }

    public void OnClickStart()
    {
        //Debug.Log("押された!");  // ログを出力

        OnClick = true;


    }
}