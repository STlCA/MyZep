using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownAnimation : MonoBehaviour
{
    protected Animator animator;
    protected TopDownCharacterController controller;

    protected void Awake()
    {
        animator = GetComponentInChildren<Animator>();
        controller = GetComponent<TopDownCharacterController>();
    }
}
