using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartButton : MonoBehaviour
{
    //[SerializeField] private CanvasGroup StartCanvas; //�L�����o�X�O���[�v�̎擾
    [SerializeField] private GameObject StartCanvas;
    [SerializeField] private GameObject NextCanvas;
    public float Cam_alpha = 1.0f; //�L�����o�X�̕s�����x
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

            NextCanvas.SetActive(true);
            StartCanvas.SetActive(false);
        }

        
    }

    public void OnClickStart()
    {
        //Debug.Log("�����ꂽ!");  // ���O���o��

        OnClick = true;


    }
}