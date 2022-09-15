using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class SnailMove : MonoBehaviour
{
    public int score = 0;
    public GameObject TimeText;
    public NavMeshAgent SnailAgent;
    private float StopSpeed = 0f;

    public GameObject PlayerSnail;
    private Vector3 _prevPosition;
    public bool onmove;
    public bool getitem;
    public Animator snailanim;
    private float eatspeed = 2.0f;
    private void Start()
    {
        // 初期位置を保持
        _prevPosition = transform.position;
    }
    void Update()
    {
        // 現在位置取得
        var position = transform.position;

        // 現在速度計算
        var velocity = (position - _prevPosition) / Time.deltaTime;

        // 前フレーム位置を更新
        _prevPosition = position;

        if (velocity == new Vector3(0.0f, 0.0f, 0.0f))
        {
            onmove = false;
        }
        else
        {
            onmove = true;
        }

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

        if (onmove)
        {
            snailanim.SetBool("walk", true);
        }
        else
        {
            snailanim.SetBool("walk", false);
        }
        if(getitem == true) //アイテム処理
        {
            this.SnailAgent.speed = 0.0f;   //アイテムをとると動きが止まる
            snailanim.SetBool("eat", true);

            eatspeed += Time.deltaTime;
            if(eatspeed >= 1.5f)
            {
                this.SnailAgent.speed = 1.5f;
                snailanim.SetBool("eat", false);
                getitem = false;
            }
        }
        else
        {
            eatspeed = 0.0f;
        }
        if (OVRInput.GetDown(OVRInput.RawButton.A))
        {
            snailanim.SetTrigger("touch");
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
