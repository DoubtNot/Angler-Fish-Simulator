using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnterVehicle : MonoBehaviour
{

    public Transform dropOffPoint;
    public GameObject vehicleCamera;
    public GameObject playerCamera;
    public GameObject player;


    public void TaskOnClick()
    {
       
        player.transform.parent = dropOffPoint;
        player.SetActive(false);
        player.transform.localPosition = Vector3.zero;

        vehicleCamera.SetActive(true);
        playerCamera.SetActive(false);
     
    }
}
