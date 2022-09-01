using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class KokeItem : MonoBehaviour
{
    public bool getitem;
    public bool oneshot;
    private float eatspeed;

    public AudioSource audioSource;
    public AudioClip soundeat;
    public AudioClip soundgauge;
    public Material ItemMaterial;
    public Texture KokeOnItemTex;
    public Texture KokeOFFItemTex;

    void Start()
    {
        ItemMaterial.SetTexture("_MainTex", KokeOnItemTex);
        ItemMaterial.SetVector("_EmissionColor", new Vector4(0.2f, 0.5f, 0.1f) * 1.5f);
    }
    void Update()
    {
        if (getitem == true)
        {
            eatspeed += Time.deltaTime;
            if(eatspeed >= 1.5f) //�H�׏I�������
            {
                ItemMaterial.SetTexture("_MainTex", KokeOFFItemTex);    //�e�N�X�`���؂�ւ�
                ItemMaterial.SetVector("_EmissionColor", new Vector4(0.2f, 0.5f, 0.1f) * 0.0f);
                oneshot = true;
            }
            if(oneshot)
            {
                audioSource.PlayOneShot(soundgauge);
                GameObject scoreTextGo = GameObject.Find("ScoreText");  //�X�R�A�̃Q�[���I�u�W�F�N�g���擾����
                scoreTextGo.SendMessage("OnScore", 1);
                oneshot = false;
            }
        }






    }
    void OnTriggerEnter(Collider other) //�Փˎ��Ɏ��s����郁�\�b�h
    {
        if (other.name == "Snali")
        {
            if(getitem == false)
            {
                audioSource.PlayOneShot(soundeat);
                getitem = true;
            }
        }
    }
}
