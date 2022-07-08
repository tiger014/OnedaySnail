using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ValveGimmick : MonoBehaviour
{
    public GameObject Obstacle; //蓋になる障害物
    public bool OffValve = false;
    float seconds;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))//タニシがコライダーに触れると
        {
            seconds = 0.0f;

            OffValve = true;
            Obstacle.SetActive(false);//蓋が消える
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //Debug.Log("離れたぜ");
            OffValve = false;
        }
    }

    void Update()
    {
        if (OffValve == false)
        {
            seconds += 1.0f;

            if (seconds >= 45.0f)//離れてから1秒くらい経ったら
            {
                Obstacle.SetActive(true);//蓋がアクティブになる

                seconds = 45.0f;
            }
        }
    }
}
