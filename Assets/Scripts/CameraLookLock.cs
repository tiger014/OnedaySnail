using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLookLock : MonoBehaviour
{
    public GameObject ChinemaCamera;

    void Update()
    {
        Camera camera = Camera.main;

        Vector3 capos = ChinemaCamera.transform.position;   //�V�l�}�J�����̃g�����X�t�H�[��

        Vector3 pos = this.transform.position;  //���̃I�u�W�F�N�g��y��capos�Ɠ���������
        pos.y = capos.y;
        this.transform.position = pos;
    }
}
