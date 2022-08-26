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
    void OnTriggerEnter(Collider other) //衝突時に実行されるメソッド
    {
        if (other.name == "Snali")
        {
            getitem = true;
        }
    }

}
