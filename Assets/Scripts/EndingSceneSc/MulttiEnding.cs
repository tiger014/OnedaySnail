using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MulttiEnding : MonoBehaviour
{
    public GameObject BadCanvas;
    public GameObject NormalCanvas;
    public GameObject TrueCanvas;
    public GameObject Badbgm;
    public GameObject Normalbgm;
    public GameObject Truebgm;
    public int Endscore = 0;

    void Start()
    {
        Debug.Log(Score.score);
        TrueCanvas.SetActive(false);
        NormalCanvas.SetActive(false);
        BadCanvas.SetActive(false);
        Truebgm.SetActive(false);
        Normalbgm.SetActive(false);
        Badbgm.SetActive(false);
    }

    void Update()
    {
        Endscore = Score.score;

        if (Endscore == 5) //ƒgƒDƒ‹[
        {
            Debug.Log("ƒgƒDƒ‹[");
            TrueCanvas.SetActive(true);
            Truebgm.SetActive(true);
        }

        if ((Endscore > 2) && (Endscore < 5)) //ƒmƒ‹ƒ}’B¬
        {
            Debug.Log("ƒmƒ‹ƒ}’B¬");
            NormalCanvas.SetActive(true);
            Normalbgm.SetActive(true);
        }

        if (Endscore < 3) //ƒmƒ‹ƒ}ˆÈ‰º
        {
            Debug.Log("ƒmƒ‹ƒ}ˆÈ‰º");
            BadCanvas.SetActive(true);
            Badbgm.SetActive(true);
        }
    }
}
