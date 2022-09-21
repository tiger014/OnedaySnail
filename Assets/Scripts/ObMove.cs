using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class ObMove : MonoBehaviour
{
    public GameObject cam;
    float mainSPEED = 0.1f;
    public Vector2 stickL;

    public bool PathMode;
    [SerializeField] private GameObject ObVirtualCamera2a;
    [SerializeField]private CinemachineVirtualCamera ObVirtualCamera2;
    private float _position = 4;
    private CinemachineTrackedDolly _dolly;
    float dollySPEED = 0.01f;
    private void Start()
    {
        // Virtual CameraÇ…ëŒÇµÇƒGetCinemachineComponentÇ≈CinemachineTrackedDollyÇéÊìæÇ∑ÇÈ
        // GetComponentÇ≈ÇÕÇ»Ç≠GetCinemachineComponentÇ»ÇÃÇ≈íçà”
        _dolly = ObVirtualCamera2.GetCinemachineComponent<CinemachineTrackedDolly>();
    }
    void Update()
    {
        Camera camera = Camera.main;
        this.transform.rotation = cam.transform.rotation;
        Quaternion Cubepos = cam.transform.rotation;
        this.transform.rotation = new Quaternion(0, Cubepos.y, 0 , Cubepos.w);
        stickL = OVRInput.Get(OVRInput.RawAxis2D.LThumbstick);
        if (!PathMode)
        {
            ObVirtualCamera2a.SetActive(false);
            //à⁄ìÆ
            Transform trans = transform;
            transform.position = trans.position;
            trans.position += trans.TransformDirection(Vector3.forward) * stickL.y * mainSPEED;
            trans.position += trans.TransformDirection(Vector3.right) * stickL.x * mainSPEED;
        }
        else
        {
            //ÉpÉXà⁄ìÆ
            ObVirtualCamera2a.SetActive(true);

            _position -= stickL.x* dollySPEED;
            _dolly.m_PathPosition = _position;
        }
    }
}
