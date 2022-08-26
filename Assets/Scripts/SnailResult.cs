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
            // ���X�Ɍ��炵�Ă���
            this.SnailAgent.speed -= StopSpeed;

            //0�ɂȂ�����~�܂�
            if (SnailAgent.speed <= 0.0f)
            {
                StopSpeed = 0f;
            }
        }
        else
        {
            SnailAgent.speed = 1.5f;
        }

        if(getitem == true) //�A�C�e������
        {
            this.SnailAgent.speed = 0.0f;   //�A�C�e�����Ƃ�Ɠ������~�܂�
            snailanim.SetBool("eat", true);
        }
    }
    void OnTriggerEnter(Collider other) //�Փˎ��Ɏ��s����郁�\�b�h
    {
        if (other.tag == "Item")
        {
            getitem = true;
        }
    }
}
