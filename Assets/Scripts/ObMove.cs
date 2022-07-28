using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObMove : MonoBehaviour
{
    public GameObject cam;
    float mainSPEED = 0.1f;
    public Vector2 stickR;

    void Update()
    {
        Camera camera = Camera.main;

        this.transform.rotation = cam.transform.rotation;

        Quaternion Cubepos = cam.transform.rotation;

        this.transform.rotation = new Quaternion(0, Cubepos.y, 0 , Cubepos.w);


        //ˆÚ“®
        stickR = OVRInput.Get(OVRInput.RawAxis2D.RThumbstick);

        Transform trans = transform;
        transform.position = trans.position;
        trans.position += trans.TransformDirection(Vector3.forward) * stickR.y * mainSPEED;
        trans.position += trans.TransformDirection(Vector3.right) * stickR.x * mainSPEED;
    }
}
