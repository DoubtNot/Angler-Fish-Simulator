using UnityEngine;
using Photon.Pun;

public class AttachPlayer : MonoBehaviour
{

    PhotonView view;


    private void FixedUpdate()
    {
        if (!view.IsMine)
        {
            return;
        }
    }

    private void Start()
    {

        view = GetComponent<PhotonView>();


        // Find the player object (assuming it has a "Player" tag)
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");

        // If player object is found, make it a child of this GameObject
        if (playerObject != null)
        {
            playerObject.transform.SetParent(transform);
        }
    }
}
