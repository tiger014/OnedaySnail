using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraChange : MonoBehaviour
{
    public Collider SnailCollider;

    public CinemachineVirtualCamera AdVCameraA1;
    public CinemachineVirtualCamera AdVCameraA2;
    public CinemachineVirtualCamera AdVCameraA3;
    public CinemachineVirtualCamera AdVCameraA4;
    public CinemachineVirtualCamera AdVCameraA5;
    public CinemachineVirtualCamera AdVCameraA6;

    public CinemachineVirtualCamera AdVCameraB1a;
    public CinemachineVirtualCamera AdVCameraB1b;
    public CinemachineVirtualCamera AdVCameraB2;
    public CinemachineVirtualCamera AdVCameraB3;
    public CinemachineVirtualCamera AdVCameraB4;
    public CinemachineVirtualCamera AdVCameraB5;
    public CinemachineVirtualCamera AdVCameraB6;
    public CinemachineVirtualCamera AdVCameraB7;



    void OnTriggerEnter(Collider other)
    {
        if (other.name == "CangePointA1")   //カメラを切り替えるポイントのコライダー
        {
            Debug.Log("CangePointA1");
            AdVCameraA1.Priority = 10; //切り替えたいカメラの優先度を10にする
            AdVCameraA2.Priority = 1;
        }
        if (other.name == "CangePointA2")
        {
            Debug.Log("CangePointA2");
            AdVCameraA1.Priority = 1;
            AdVCameraA2.Priority = 10;
            AdVCameraA3.Priority = 1;
            AdVCameraA4.Priority = 1;
        }
        if (other.name == "CangePointA3")
        {
            Debug.Log("CangePointA3");
            AdVCameraA2.Priority = 1;
            AdVCameraA3.Priority = 10;
            AdVCameraB2.Priority = 1;
        }
        if (other.name == "CangePointA4")
        {
            Debug.Log("CangePointA4");
            AdVCameraA2.Priority = 1;
            AdVCameraA4.Priority = 10;
            AdVCameraA5.Priority = 1;
        }
        if (other.name == "CangePointA5")
        {
            Debug.Log("CangePointA5");
            AdVCameraA4.Priority = 1;
            AdVCameraA5.Priority = 10;
            AdVCameraA6.Priority = 1;
        }
        if (other.name == "CangePointA6")
        {
            Debug.Log("CangePointA6");
            AdVCameraA5.Priority = 1;
            AdVCameraA6.Priority = 10;
            AdVCameraB1a.Priority = 1;
        }
        if (other.name == "CangePointB1a")
        {
            Debug.Log("CangePointB1a");
            AdVCameraA6.Priority = 1;
            AdVCameraB1a.Priority = 10;
            AdVCameraB1b.Priority = 1;
            AdVCameraB5.Priority = 1;
        }
        if (other.name == "CangePointB1b")
        {
            Debug.Log("CangePointB1b");
            AdVCameraB1a.Priority = 1;
            AdVCameraB1b.Priority = 10;
            AdVCameraB2.Priority = 1;
        }
        if (other.name == "CangePointB2")
        {
            Debug.Log("CangePointB2");
            AdVCameraA3.Priority = 1;
            AdVCameraB1b.Priority = 1;
            AdVCameraB2.Priority = 10;
            AdVCameraB3.Priority = 1;
        }
        if (other.name == "CangePointB3")
        {
            Debug.Log("CangePointB3");
            AdVCameraB2.Priority = 1;
            AdVCameraB3.Priority = 10;
            AdVCameraB4.Priority = 1;
        }
        if (other.name == "CangePointB4")
        {
            Debug.Log("CangePointB4");
            AdVCameraB3.Priority = 1;
            AdVCameraB4.Priority = 10;
            AdVCameraB5.Priority = 1;
        }
        if (other.name == "CangePointB5")
        {
            Debug.Log("CangePointB5");
            AdVCameraB1a.Priority = 1;
            AdVCameraB5.Priority = 10;
            AdVCameraB6.Priority = 1;
        }
        if (other.name == "CangePointB6")
        {
            Debug.Log("CangePointB6");
            AdVCameraB5.Priority = 1;
            AdVCameraB6.Priority = 10;
            AdVCameraB7.Priority = 1;
        }
        if (other.name == "CangePointB7")
        {
            Debug.Log("CangePointB7");
            AdVCameraB6.Priority = 1;
            AdVCameraB7.Priority = 10;
        }
    }
}