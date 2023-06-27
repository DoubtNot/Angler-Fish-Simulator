using UnityEngine;

public class ResetPlayerLocation : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Boat"))
        {
            other.transform.position = Vector3.zero;
        }
    }
}
