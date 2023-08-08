using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody))]
public class PlayerControllerSolo : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private FixedJoystick _joystick;
    [SerializeField] private float _moveSpeed;

    public GameObject skateboard;
    public GameObject boat;

    public GameObject skateboardOffButton;
    public GameObject boatOffButton;

    public Button sk8BoardOnButton;
   
    private bool isBoatActive = false;
    private bool isSkateboardOn = false;

    [SerializeField] Transform cam;

    public void BoatMovementSpeed()
    {
        _moveSpeed = 40f; //Speed for the player when the boat is activated
    }

    public void PlayerMovementSpeed()
    {
        _moveSpeed = 20f; //Speed of the player when the boat is not active
    }

    public void CloseApp()
    {
        // Close the application
        Application.Quit();
        Debug.Log("I guess I'm done playing for now..");
    }

    private void FixedUpdate()
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

        if (isBoatActive || isSkateboardOn)
        {
            BoatMovementSpeed();
        }
        else
        {
            PlayerMovementSpeed();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Water"))
        {
            // Deactivate skateboard and disable its OFF button
            skateboard.SetActive(false);
            skateboardOffButton.SetActive(false);
            isSkateboardOn = false;
            sk8BoardOnButton.interactable = false; // If the player has collided with the water then the sk8Board ON button won't work
        }

        if (other.CompareTag("ToiletWater"))
        {
            transform.position = new Vector3 (0,-10,0);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Land"))
        {
            // Deactivate boat and disable its button
            boat.SetActive(false);
            boatOffButton.SetActive(false);
            isBoatActive = false;
            sk8BoardOnButton.interactable = true; // If the player has collided with the land then the sk8Board ON button will work.
        }
    }

    public void OnBoatOnButtonPressed()
    {
        isBoatActive = true;
        isSkateboardOn = false;

        sk8BoardOnButton.interactable = false;
    }

    public void OnSk8BoardOnButtonPressed()
    {
        isBoatActive = false;
        isSkateboardOn = true;
    }

    public void OnBoatSk8OffButtonPressed()
    {
        isBoatActive = false;
        isSkateboardOn = false;

        boatOffButton.SetActive(false);
        skateboardOffButton.SetActive(false);
    }
}