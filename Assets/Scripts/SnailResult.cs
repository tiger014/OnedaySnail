using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class SnailResult : MonoBehaviour
{
    public int score = 0;
    public GameObject TimeText;
    public NavMeshAgent SnailAgent;
    private float StopSpeed = 0.04f;

    void Update()
    {
        if (TimeText.GetComponent<Timer>().TimeOver == true)
        {
            //Debug.Log("Stop");
            // 徐々に減らしていく
            this.SnailAgent.speed -= StopSpeed;

            //0になったら止まる
            if (SnailAgent.speed <= 0.0f)
            {
                StopSpeed = 0f;
            }

        }
    }
}
