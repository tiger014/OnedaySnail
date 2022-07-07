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

        if (Endscore == 5) //トゥルー
        {
            Debug.Log("トゥルー");
            TrueCanvas.SetActive(true);

        }

        if ((Endscore > 2) && (Endscore < 5)) //ノルマ達成
        {
            Debug.Log("ノルマ達成");
            NormalCanvas.SetActive(true);

        }

        if (Endscore < 3) //ノルマ以下
        {
            Debug.Log("ノルマ以下");
            BadCanvas.SetActive(true);

        }
    }
}
