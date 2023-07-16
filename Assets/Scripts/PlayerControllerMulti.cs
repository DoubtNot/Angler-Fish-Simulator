using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Cinemachine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody))]
public class PlayerControllerMulti : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private FixedJoystick _joystick;
    [SerializeField] private float _moveSpeed;


    [SerializeField] Transform cam;

    public GameObject childCannon;
    public GameObject childFishingPole;
    public GameObject childBoat;


    PhotonView view;


    void Awake ()
    {
        view = GetComponent<PhotonView>();
    }

    public void BoatMovementSpeed()
    {
        _moveSpeed = 40f; //Speed for the player when the boat is activated
    }

    public void PlayerMovementSpeed()
    {
        _moveSpeed = 20f; //Speed of the player when the boat is not active
    }

    public void DisconnectPlayer()
    {
        PhotonNetwork.Disconnect();
    }

    public void CloseApp()
    {
        // Close the application
        Application.Quit();
        Debug.Log("I guess I'm done playing for now..");
    }

    private void FixedUpdate()
    {
        if (!view.IsMine)
        {
            return;
        }

        if (view.IsMine) //Adding directional force to the player using UI joysticks
        {
            float hinput = _joystick.Horizontal * _moveSpeed;
            float vinput = _joystick.Vertical * _moveSpeed;

            //camera direction
            Vector3 camForward = cam.forward;
            Vector3 camRight = cam.right;

            camForward.y = 0;
            camRight.y = 0;

            //creating relative camera direction
            Vector3 forwardRelative = vinput * camForward;
            Vector3 rightRelative = hinput * camRight;

            Vector3 moveDirection = forwardRelative + rightRelative;

            _rigidbody.velocity = new Vector3(moveDirection.x, _rigidbody.velocity.y, moveDirection.z);

            if (_joystick.Horizontal != 0 || _joystick.Vertical != 0)
            {
                transform.rotation = Quaternion.LookRotation(_rigidbody.velocity);
            }

        }
       
              
    }


    // Enable the child game object and synchronize across the network
    [PunRPC]
    void EnableChildCannonObject()
    {
        childCannon.SetActive(true);
    }

    // Disable the child game object and synchronize across the network
    [PunRPC]
    void DisableChildCannonObject()
    {
        childCannon.SetActive(false);
    }

    // Call this method when you want to enable the child object
    public void EnableChildCannonObjectRPC()
    {
        view.RPC("EnableChildCannonObject", RpcTarget.All);
    }

    // Call this method when you want to disable the child object
    public void DisableChildCannonObjectRPC()
    {
        view.RPC("DisableChildCannonObject", RpcTarget.All);
    }

    // Enable the child game object and synchronize across the network
    [PunRPC]
    void EnableChildFishingPoleObject()
    {
        childFishingPole.SetActive(true);
    }

    // Disable the child game object and synchronize across the network
    [PunRPC]
    void DisableChildFishingPoleObject()
    {
        childFishingPole.SetActive(false);
    }

    // Call this method when you want to enable the child object
    public void EnableChildFishingPoleObjectRPC()
    {
        view.RPC("EnableChildFishingPoleObject", RpcTarget.All);
    }

    // Call this method when you want to disable the child object
    public void DisableChildFishingPoleObjectRPC()
    {
        view.RPC("DisableChildFishingPoleObject", RpcTarget.All);
    }

    // Enable the child game object and synchronize across the network
    [PunRPC]
    void EnableChildBoatObject()
    {
        childBoat.SetActive(true);
    }

    // Disable the child game object and synchronize across the network
    [PunRPC]
    void DisableChildBoatObject()
    {
        childBoat.SetActive(false);
    }

    // Call this method when you want to enable the child object
    public void EnableChildBoatObjectRPC()
    {
        view.RPC("EnableChildBoatObject", RpcTarget.All);
    }

    // Call this method when you want to disable the child object
    public void DisableChildBoatObjectRPC()
    {
        view.RPC("DisableChildBoatObject", RpcTarget.All);
    }
}