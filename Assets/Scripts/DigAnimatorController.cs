using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DigAnimatorController : MonoBehaviour
{
    public Animator animator;

    private void Start()
    {
        // Assuming you have assigned the Animator component to the script in the Inspector
        animator = GetComponent<Animator>();
    }

    public void PlayDigAnimation()
    {
        // Play and restart the specific animation
        animator.Play("Dig",0, 0f);
        Debug.Log("im diging im digning!!");
    }
}
