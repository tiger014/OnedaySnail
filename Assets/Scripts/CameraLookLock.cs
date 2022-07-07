using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLookLock : MonoBehaviour
{
    public GameObject ChinemaCamera;

    void Update()
    {
        Camera camera = Camera.main;

        Vector3 capos = ChinemaCamera.transform.position;   //シネマカメラのトランスフォーム

        Vector3 pos = this.transform.position;  //このオブジェクトのyをcaposと同期させる
        pos.y = capos.y;
        this.transform.position = pos;
    }
}
