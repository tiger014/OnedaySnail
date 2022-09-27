using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class SnailMove : MonoBehaviour
{
    public int score = 0;
    public GameObject TimeText;
    public GameObject StoryImage1;
    public GameObject StoryImage2;
    public GameObject StoryImage3;
    public GameObject StoryImage4;
    public GameObject StoryImage5;
    public ParticleSystem particle1;
    public ParticleSystem particle2;
    public ParticleSystem particle3;
    public ParticleSystem particle4;
    public ParticleSystem particle5;

    public NavMeshAgent SnailAgent;
    private float StopSpeed = 0f;

    public GameObject PlayerSnail;
    private Vector3 _prevPosition;
    public bool onmove;
    public bool getitem;
    public Animator snailanim;
    private float eatspeed;
    public int _panelno;
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
        if(getitem) //�A�C�e������
        {
            this.SnailAgent.speed = 0.0f;   //�A�C�e�����Ƃ�Ɠ������~�܂�
            snailanim.SetBool("eat", true);

            eatspeed += Time.deltaTime;
            if (eatspeed >= 1.5f)
            {
                switch (_panelno)
                {
                    case 1:
                        StoryImage1.SetActive(true);
                        break;
                    case 2:
                        StoryImage2.SetActive(true);
                        break;
                    case 3:
                        StoryImage3.SetActive(true);
                        break;
                    case 4:
                        StoryImage4.SetActive(true);
                        break;
                    case 5:
                        StoryImage5.SetActive(true);
                        break;
                    //�f�t�H���g����
                    default:
                        Debug.Log("�X�g�[���[�p�l���ɃG���[������܂�����");
                        break;
                }
            }
        }
        else
        {
            eatspeed = 0.0f;
            StoryImage1.SetActive(false);
            StoryImage2.SetActive(false);
            StoryImage3.SetActive(false);
            StoryImage4.SetActive(false);
            StoryImage5.SetActive(false);
        }
        if ((OVRInput.GetDown(OVRInput.RawButton.A))||(Input.GetKey(KeyCode.Space)))
        {
            //snailanim.SetTrigger("touch");
        }
    }
    void OnTriggerEnter(Collider other) //�Փˎ��Ɏ��s����郁�\�b�h
    {
        if (other.tag == "Item")
        {
            getitem = true;
            _panelno += 1;
        }
    }
    public void OFFClickStory()
    {
        this.SnailAgent.speed = 1.5f;

        snailanim.SetBool("eat", false);
        getitem = false;
    }
}
