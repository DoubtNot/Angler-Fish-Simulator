using UnityEngine;
using UnityEngine.UI;

public class CamAnimationController : MonoBehaviour
{
    public Animator animator;

    private void Start()
    {
        // Assuming you have assigned the Animator component to the script in the Inspector
        animator = GetComponent<Animator>();
    }

    public void PlayZoomAnimation()
    {
        // Play the specific animation
        animator.Play("CameraZoomIntoWhiteboard");
    }

    public void PlayRetreatAnimation()
    {
        animator.Play("CameraZoomOutFromWhiteboard");
    }
}
