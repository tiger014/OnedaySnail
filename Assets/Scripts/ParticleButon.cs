using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleButon : MonoBehaviour
{
    public SphereCollider kokeco1;
    public SphereCollider kokeco2;
    public SphereCollider kokeco3;
    public SphereCollider kokeco4;
    public SphereCollider kokeco5;
    public ParticleSystem particle1;
    public ParticleSystem particle2;
    public ParticleSystem particle3;
    public ParticleSystem particle4;
    public ParticleSystem particle5;
    public AudioSource audioSource;
    public AudioClip soundgauge;
    public int b;
    private void Update()
    {
        if(kokeco1.enabled == false)
        {
            b = 1;
        }
        if (kokeco2.enabled == false)
        {
            b = 2;
        }
        if (kokeco3.enabled == false)
        {
            b = 3;
        }
        if (kokeco4.enabled == false)
        {
            b = 4;
        }
        if (kokeco5.enabled == false)
        {
            b = 5;
        }
    }
    public void OnClickStory()
    {
        audioSource.PlayOneShot(soundgauge);
        switch (b)
        {
            case 1:
                particle1.Play();
                break;
            case 2:
                particle2.Play();
                break;
            case 3:
                particle3.Play();
                break;
            case 4:
                particle4.Play();
                break;
            case 5:
                particle5.Play();
                break;
            //デフォルト処理
            default:
                Debug.Log("コケパーティクルにエラーがあります多分");
                break;
        }
    }
}
