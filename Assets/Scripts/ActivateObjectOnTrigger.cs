using UnityEngine;

public class ActivateObjectOnTrigger : MonoBehaviour
{
    public GameObject objectToActivate;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Boat"))
        {
            objectToActivate.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Boat"))
        {
            objectToActivate.SetActive(false);
        }
    }
}
