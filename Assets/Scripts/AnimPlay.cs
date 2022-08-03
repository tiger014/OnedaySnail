using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimPlay : MonoBehaviour
{
    public Animator Hasu1;
    public Animator Hasu2;
    public Animator Hasu3;
    public Animator Hasu4;
    public Animator Hasu5;
    void Start()
    {
        Hasu1.Play(Hasu1.GetCurrentAnimatorStateInfo(0).shortNameHash, 0, 0.7f);
        Hasu2.Play(Hasu2.GetCurrentAnimatorStateInfo(0).shortNameHash, 0, 0.5f);
        Hasu3.Play(Hasu3.GetCurrentAnimatorStateInfo(0).shortNameHash, 0, 0.7f);
        Hasu4.Play(Hasu4.GetCurrentAnimatorStateInfo(0).shortNameHash, 0, 0.2f);
        Hasu5.Play(Hasu5.GetCurrentAnimatorStateInfo(0).shortNameHash, 0, 0.6f);
    }
}
