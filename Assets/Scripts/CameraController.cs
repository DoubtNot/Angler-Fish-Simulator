using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using Photon.Pun;


public class CameraController : MonoBehaviour
{
    public Joystick joystick;
    public CinemachineFreeLook freeLookCamera;
    public float rotationSpeed = 1.5f;
    public float verticalSpeedMultiplier = 0.5f;

    PhotonView view;


    private void Start()
    {
        view = GetComponent<PhotonView>();

    }

    void Update()
    {

        if (view.IsMine)
        {
            // Get joystick input values
            float horizontalInput = joystick.Horizontal;
            float verticalInput = joystick.Vertical;

            // Calculate rotation angles based on joystick input
            float rotationX = verticalInput * rotationSpeed * verticalSpeedMultiplier;
            float rotationY = horizontalInput * rotationSpeed;

            // Adjust the camera's rotation using Cinemachine
            freeLookCamera.m_XAxis.Value += rotationY;
            freeLookCamera.m_YAxis.Value += rotationX;
        }
           
    }
}
