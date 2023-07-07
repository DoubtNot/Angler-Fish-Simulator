using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class BoatController : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private FixedJoystick _joystick;
    [SerializeField] private float _moveSpeed;

    [SerializeField] Transform cam;

    public GameObject childPlayer;
    public GameObject boat;

    PhotonView view;


    void Awake()
    {
        view = GetComponent<PhotonView>();
    }

    private void FixedUpdate()
    {
        if (!view.IsMine)
        {
            return;
        }


        if (view.IsMine)
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

        // Disable the child game object and synchronize across the network
        [PunRPC]
    void DisableChildPlayerObject()
    {
        boat.SetActive(false);
    }

    // Call this method when you want to Disable the child object
    public void DisableChildObjectRPC()
    {
        view.RPC("DisableChildPlayerObject", RpcTarget.All);
    }
}
