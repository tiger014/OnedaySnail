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
    float sy;
    float _KHz;
    float _OHz;

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

        _KHz = kagopos.y - 3.27f;
        Vector3 khimo;
        khimo = KagoHimo.transform.localScale;
        khimo.z = 90 - _KHz * 40;
        if (khimo.z <= 0)
        {
            khimo.z = 0;
        }
        KagoHimo.transform.localScale = khimo;

        _OHz = omoripos.y - 3.27f;
        Vector3 ohimo;
        ohimo = OmoriHimo.transform.localScale;
        ohimo.z = 90 - _OHz * 47;
        if (ohimo.z <= 0)
        {
            ohimo.z = 0;
        }
        OmoriHimo.transform.localScale = ohimo;

        Kago.transform.position = kagopos;
        Omori.transform.position = omoripos;
    }
}
