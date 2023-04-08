using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    private Transform m_Cam;
    private Vector3 m_CamForward;
    private Vector3 m_Move;
    public float Hinput;
    public float Vinput;

    private void Start()
    {
        if (Camera.main != null)
        {
            m_Cam = Camera.main.transform;
        }
    }

    private void FixedUpdate()
    {
        if (m_Cam != null)
        {
            m_CamForward = Vector3.Scale(m_Cam.forward, new Vector3(1, 0, 1)).normalized;
            m_Move = Vinput * m_CamForward + Hinput * m_Cam.right;
        }
        else
        {
            m_Move = Vinput * Vector3.forward + Hinput * Vector3.right;
        }
    }

    private void Update()
    {
        
    }
}
