using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class StageCameraMode : MonoBehaviour
{
    [SerializeField]
    private CinemachineVirtualCamera _virtualCamera;
    [SerializeField]
    private float _position; //パスポジション
    private CinemachineTrackedDolly _dolly;

    public float walkspeed = 1f;//パス移動スピード
    public Vector2 stickR;

    // Start is called before the first frame update
    void Start()
    {
        _dolly = _virtualCamera.GetCinemachineComponent<CinemachineTrackedDolly>();
    }

    // Update is called once per frame
    void Update()
    {
        stickR = OVRInput.Get(OVRInput.RawAxis2D.RThumbstick);//右スティック
        //_dolly.m_PathPosition = _position;

        //移動
        if (stickR.x < 0)
        {
            _dolly.m_PathPosition +=  walkspeed * Time.deltaTime;
        }
        if (stickR.x > 0)
        {
            _dolly.m_PathPosition -=  walkspeed * Time.deltaTime;
        }



    }
}
