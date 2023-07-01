using UnityEngine;
using UnityEngine.UI;

public class AnimationController : MonoBehaviour
{
    public Animator animator;

    private void Start()
    {
        // Assuming you have assigned the Animator component to the script in the Inspector
        animator = GetComponent<Animator>();
    }

    public void PlayAnimation()
    {
        // Play the specific animation
        animator.Play("CameraZoomIntoWhiteboard");
    }
}
