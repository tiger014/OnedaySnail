using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class KokeItem : MonoBehaviour
{
    public int a;   //�؂�ւ��ԍ�

    public AudioSource audioSource;
    public AudioClip soundeat;
    public AudioClip soundgauge;

    public Material ItemMaterial;
    public Texture KokeOnItemTex;
    public Texture KokeOFFItemTex;

    public Image StoryImage;
    public GameObject DeleteButton;

    bool Scene1;
    bool Scene2;
    bool Scene3;
    bool Scene4;
    void Start()
    {
        a = 0;
    }
    void OnTriggerEnter(Collider other) //�Փˎ��Ɏ��s����郁�\�b�h
    {
        if (other.name == "Snali")
        {
            a = 1;
            Scene1 = true;
        }
    }
    void Update()
    {
        
    }
    void Item_flow()
    {
        switch (a)
        {
            case 1:
                Debug.Log("�V�[��1");

                break;
            case 2:
                Debug.Log("�V�[��2");

                break;
            case 3:
                Debug.Log("�V�[��3");

                break;
            case 4:
                Debug.Log("�V�[��4");

                break;
        }
    }
    public void OnClick()   //�{�^�����������Ƃ�
    {

    }
}
