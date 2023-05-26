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
    public GameObject boat;

    public void TaskEnterOnClick()
    {
       
        player.SetActive(false);
        boat.SetActive(true);

        player.transform.rotation = Quaternion.Euler(0, 0, 0);


        vehicleCamera.SetActive(true);
        playerCamera.SetActive(false);
     
    }

    public void TaskExitOnClick()
    {

        player.SetActive(true);
        boat.SetActive(false);

        player.transform.parent = dropOffPoint;
        player.transform.localPosition = Vector3.zero;
        boat.transform.rotation = Quaternion.Euler(0, 0, 0);



        vehicleCamera.SetActive(false);
        playerCamera.SetActive(true);

    }
}
