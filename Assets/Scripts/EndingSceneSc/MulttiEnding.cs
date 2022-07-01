using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MulttiEnding : MonoBehaviour
{
    public GameObject BadCanvas;
    public GameObject NormalCanvas;
    public GameObject TrueCanvas;
    public int Endscore = 0;

    void Start()
    {
        Debug.Log(Score.score);
    }

    void Update()
    {
        Endscore = Score.score;

        if (Endscore == 5) //�g�D���[
        {
            Debug.Log("�g�D���[");
            TrueCanvas.SetActive(true);

        }
        if ((Endscore > 2) && (Endscore < 5)) //�m���}�B��
        {
            Debug.Log("�m���}�B��");
            NormalCanvas.SetActive(true);
        }
        if (Endscore < 3) //�m���}�ȉ�
        {
            Debug.Log("�m���}�ȉ�");
            BadCanvas.SetActive(true);
        }
    }
}
