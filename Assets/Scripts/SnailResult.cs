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

    public bool getitem;
    public Animator snailanim;

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
        else
        {
            SnailAgent.speed = 1.5f;
        }

        if(getitem == true) //アイテム処理
        {
            this.SnailAgent.speed = 0.0f;   //アイテムをとると動きが止まる
            snailanim.SetBool("eat", true);
        }
    }
    void OnTriggerEnter(Collider other) //衝突時に実行されるメソッド
    {
        if (other.tag == "Item")
        {
            getitem = true;
        }
    }
}
