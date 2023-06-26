using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TentacleAnimationSwitch : MonoBehaviour
{
    private Animator animator;
    private bool isPlayingFirstAnimation = true;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (isPlayingFirstAnimation && !animator.IsInTransition(0))
        {
            isPlayingFirstAnimation = false;
            animator.SetBool("SwitchAnimation", true); // Set the parameter to true to start the second animation.
        }
    }
}
