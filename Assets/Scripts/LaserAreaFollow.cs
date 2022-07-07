using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserAreaFollow : MonoBehaviour
{
    public GameObject Snail;

    void Update()
    {

        this.transform.position = Snail.transform.position;
        this.transform.rotation = Snail.transform.rotation;
    }
}
