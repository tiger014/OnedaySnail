using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObMove : MonoBehaviour
{
    public GameObject cam;
    float mainSPEED = 0.1f;
    public Vector2 stickL;

    void Update()
    {
        Camera camera = Camera.main;

        this.transform.rotation = cam.transform.rotation;

        Quaternion Cubepos = cam.transform.rotation;

        this.transform.rotation = new Quaternion(0, Cubepos.y, 0 , Cubepos.w);


        //ˆÚ“®
        stickL = OVRInput.Get(OVRInput.RawAxis2D.LThumbstick);

        Transform trans = transform;
        transform.position = trans.position;
        trans.position += trans.TransformDirection(Vector3.forward) * stickL.y * mainSPEED;
        trans.position += trans.TransformDirection(Vector3.right) * stickL.x * mainSPEED;
    }
}
