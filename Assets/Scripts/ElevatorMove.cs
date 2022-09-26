using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorMove : MonoBehaviour
{
    public GameObject Snail;
    public GameObject Kago;
    public GameObject Omori;
    public GameObject KagoHimo;
    public GameObject OmoriHimo;
    public float sy;
    public float _KHz;
    public float _OHz;

    void Update()
    {
        sy = Snail.transform.position.y;
        Vector3 kagopos = Kago.transform.position;
        kagopos.y = sy + 1.2f;
        if(kagopos.y <= 3.27f)
        {
            kagopos.y = 3.27f;
        }
        else if(kagopos.y >= 6.72f)
        {
            kagopos.y = 6.72f;
        }

        Vector3 omoripos = Omori.transform.position;
        omoripos.y = -kagopos.y + 10f;
        if (omoripos.y >= 5.2f)
        {
            omoripos.y = 5.2f;
        }

        Kago.transform.position = kagopos;
        Omori.transform.position = omoripos;




    }
}
