using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class KokeItem : MonoBehaviour
{
    public bool getitem;
    public bool aftaim;

    public AudioSource audioSource;
    public AudioClip soundeat;
    public AudioClip soundgauge;

    void Start()
    {

    }
    void Update()
    {
        if (getitem == true)
        {
            //audioSource.PlayOneShot(soundeat);
        }

    }
    void OnTriggerEnter(Collider other) //�Փˎ��Ɏ��s����郁�\�b�h
    {
        if (other.name == "Snali")
        {
            getitem = true;
        }
    }

}
