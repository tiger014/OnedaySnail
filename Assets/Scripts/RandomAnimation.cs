using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomAnimation: MonoBehaviour
{
    //�A�j���[�V�����������_���Ȉʒu����Đ�����
    public Animator animator;

    void Start()
    {
        animator.Play(animator.GetCurrentAnimatorStateInfo(0).shortNameHash, 0, Random.Range(0f, 1f));
    }
}
