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
        // �����ʒu��ێ�
        _prevPosition = transform.position;
    }
    void Update()
    {
        // ���݈ʒu�擾
        var position = transform.position;

        // ���ݑ��x�v�Z
        var velocity = (position - _prevPosition) / Time.deltaTime;

        // �O�t���[���ʒu���X�V
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

        if (onmove)
        {
            snailanim.SetBool("walk", true);
        }
        else
        {
            snailanim.SetBool("walk", false);
        }
        if(getitem == true) //�A�C�e������
        {
            this.SnailAgent.speed = 0.0f;   //�A�C�e�����Ƃ�Ɠ������~�܂�
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
    void OnTriggerEnter(Collider other) //�Փˎ��Ɏ��s����郁�\�b�h
    {
        if (other.tag == "Item")
        {
            getitem = true;
        }
    }
}
