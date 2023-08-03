using UnityEngine;

public class DestroyGrassOnButtonPress : MonoBehaviour
{
    public bool isInGrassTrigger = false;
    private GameObject grassObject;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Grass"))
        {
            isInGrassTrigger = true;
            grassObject = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Grass"))
        {
            isInGrassTrigger = false;
            grassObject = null;
        }
    }

    public void OnButtonPress()
    {
        if (isInGrassTrigger && grassObject != null)
        {
            Destroy(grassObject);
        }
    }
}
