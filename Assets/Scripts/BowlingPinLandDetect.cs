using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowlingPinLandDetect : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Land"))
        {
            Debug.Log("Land Collision Detected");
            Destroy(this.gameObject, 5f); // Destroy the parent of the object with this script
        }
    }
}
