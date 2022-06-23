using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraSyncRig : MonoBehaviour
{
    public GameObject cam;

    void Update()
    {
        Camera camera = Camera.main;

        this.transform.position = cam.transform.position;
        this.transform.rotation = cam.transform.rotation;
    }
}
