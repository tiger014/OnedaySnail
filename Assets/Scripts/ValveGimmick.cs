using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ValveGimmick : MonoBehaviour
{
    public GameObject Obstacle; //�W�ɂȂ��Q��
    public bool OffValve = false;
    float seconds;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))//�^�j�V���R���C�_�[�ɐG����
        {
            seconds = 0.0f;

            OffValve = true;
            Obstacle.SetActive(false);//�W��������
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //Debug.Log("���ꂽ��");
            OffValve = false;
        }
    }

    void Update()
    {
        if (OffValve == false)
        {
            seconds += 1.0f;

            if (seconds >= 45.0f)//����Ă���1�b���炢�o������
            {
                Obstacle.SetActive(true);//�W���A�N�e�B�u�ɂȂ�

                seconds = 45.0f;
            }
        }
    }
}
