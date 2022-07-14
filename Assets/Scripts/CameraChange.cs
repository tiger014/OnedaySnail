using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraChange : MonoBehaviour
{
    public Collider SnailCollider;

    public CinemachineVirtualCamera SFVirtualCamera1;
    public CinemachineVirtualCamera SFVirtualCamera2;
    public CinemachineVirtualCamera SFVirtualCamera3;
    public CinemachineVirtualCamera SFVirtualCamera4;


    void OnTriggerEnter(Collider other)
    {
        if (other.name == "ChineCangePoint1")   //�J������؂�ւ���|�C���g�̃R���C�_�[
        {
            Debug.Log("CameraPoint1�G�ꂽ��I");
            SFVirtualCamera1.Priority = 10; //�؂�ւ������J�����̗D��x��10�ɂ���
            SFVirtualCamera2.Priority = 1;
        }

        if (other.name == "ChineCangePoint2")
        {
            Debug.Log("CameraPoint2�G�ꂽ��I");
            SFVirtualCamera1.Priority = 1;
            SFVirtualCamera2.Priority = 10;
            SFVirtualCamera3.Priority = 1;
            SFVirtualCamera4.Priority = 1;
        }

        if (other.name == "ChineCangePoint3")
        {
            Debug.Log("CameraPoint3�G�ꂽ��I");
            SFVirtualCamera1.Priority = 1;
            SFVirtualCamera2.Priority = 1;
            SFVirtualCamera3.Priority = 10;
            SFVirtualCamera4.Priority = 1;
        }

        if (other.name == "ChineCangePoint4")
        {
            Debug.Log("CameraPoint4�G�ꂽ��I");
            SFVirtualCamera1.Priority = 1;
            SFVirtualCamera2.Priority = 1;
            SFVirtualCamera3.Priority = 1;
            SFVirtualCamera4.Priority = 10;
        }
    }
}