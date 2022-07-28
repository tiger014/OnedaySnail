using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObCame : MonoBehaviour
{
    public GameObject Cube;
    void Update()
    {
       this.transform.position = Cube.transform.position;
    }
}
