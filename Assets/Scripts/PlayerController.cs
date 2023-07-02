using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private FixedJoystick _joystick;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _boostTimer;
    [SerializeField] private bool boosting;

    [SerializeField] Transform cam;

    public GameObject digButton;
    public GameObject treasureDigButton;

    PhotonView view;


    private void Start()
    {
        _boostTimer = 0;
        boosting = false;

        view = GetComponent<PhotonView>();
    }
    private void Update()
    {
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

            if (boosting)
            {
                _boostTimer += Time.deltaTime;
                _moveSpeed = 60;

                if (_boostTimer >= 10)
                {
                    _boostTimer = 0;
                    boosting = false;
                    _moveSpeed = 35;
                }
            }
        }
       
              
    }

    private void OnTriggerEnter(Collider collision) 
    {
        if (collision.gameObject.tag == "SpeedUpZone") 
        {
            boosting = true;
        }
        if (collision.gameObject.tag == "Treasure")
        {
            digButton.SetActive (false);
            treasureDigButton.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.tag == "Treasure")
        {
            digButton.SetActive(true);
            treasureDigButton.SetActive(false);
        }
    }

}