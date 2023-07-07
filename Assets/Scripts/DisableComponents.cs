using UnityEngine;
using Photon.Pun;

public class DisableComponents : MonoBehaviour
{
    public GameObject targetObject; // Reference to the GameObject to disable scripts, Rigidbody, and Collider on
    public MonoBehaviour[] scriptsToDisable; // Array of scripts to disable
    public GameObject boatChild;
    public GameObject playerChild;

    private Rigidbody targetRigidbody; // Reference to the Rigidbody component on the target object
    private Collider targetCollider; // Reference to the Collider component on the target object
    private bool componentsDisabled = false; // Flag to track whether components are currently disabled

    PhotonView view;


    private void Awake()
    {
        targetRigidbody = targetObject.GetComponent<Rigidbody>();
        targetCollider = targetObject.GetComponent<Collider>();
        view = GetComponent<PhotonView>();
    }

    private void FixedUpdate()
    {
        if (!view.IsMine)
        {
            return;
        }
    }

    public void DisableComponentsOnTarget()
    {
      
        if (view.IsMine)
        {
            if (targetObject == null)
            {
                Debug.LogWarning("Target object not assigned!");
                return;
            }

            if (componentsDisabled)
            {
                // Components are already disabled, so no need to disable them again
                return;
            }

            // Disable scripts
            for (int i = 0; i < scriptsToDisable.Length; i++)
            {
                scriptsToDisable[i].enabled = false;
            }

            // Disable Rigidbody
            if (targetRigidbody != null)
            {
                targetRigidbody.isKinematic = true;
            }

            // Disable Collider
            if (targetCollider != null)
            {
                targetCollider.enabled = false;
            }

            componentsDisabled = true; // Set the flag to indicate that components are disabled
        }
    }

    public void EnableComponentsOnTarget()
    {
        if (view.IsMine)
        {
            if (targetObject == null)
            {
                Debug.LogWarning("Target object not assigned!");
                return;
            }

            if (!componentsDisabled)
            {
                // Components are already enabled, so no need to enable them again
                return;
            }

            // Enable scripts
            for (int i = 0; i < scriptsToDisable.Length; i++)
            {
                scriptsToDisable[i].enabled = true;
            }

            // Enable Rigidbody
            if (targetRigidbody != null)
            {
                targetRigidbody.isKinematic = false;
            }

            // Enable Collider
            if (targetCollider != null)
            {
                targetCollider.enabled = true;
            }

            componentsDisabled = false; // Set the flag to indicate that components are enabled again
        }
    }

    public void RemoveBoatChildFromParent()
    {
        if (view.IsMine)
        {
            // Check if the child object and its parent are valid
            if (boatChild != null && boatChild.transform.parent != null)
            {
                // Remove the child object from its parent
                boatChild.transform.parent = null;
            }
        }
    }

    public void RemovePlayerChildFromParent()
    {
        if (view.IsMine)
        {
            // Check if the child object and its parent are valid
            if (playerChild != null && playerChild.transform.parent != null)
            {
                // Remove the child object from its parent
                playerChild.transform.parent = null;
            }
        }
    }

    public void SetBoatAsChild()
    {
        if (view.IsMine)
        {
            // Check if both childObject and parentObject are assigned
            if (boatChild != null && playerChild != null)
            {
                // Set childObject as a child of parentObject
                boatChild.transform.SetParent(playerChild.transform);
            }
        }
    }

    public void SetPlayerAsChild()
    {
        if (view.IsMine)
        {
            // Check if both childObject and parentObject are assigned
            if (boatChild != null && playerChild != null)
            {
                // Set childObject as a child of parentObject
                playerChild.transform.SetParent(boatChild.transform);
            }
        }
    }
}
