using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnterVehicle : MonoBehaviour
{

    public Transform playerDropOffPoint;
    public Transform boatDropOffPoint;
    public GameObject vehicleCamera;
    public GameObject playerCamera;
    public GameObject player;
    public GameObject boat;
    public GameObject dockedBoat;

    public void TaskEnterOnClick()
    {
       
        player.SetActive(false);
        dockedBoat.SetActive(false);
        boat.SetActive(true);

        boat.transform.parent = boatDropOffPoint;
        boat.transform.localPosition = Vector3.zero;
        player.transform.rotation = Quaternion.Euler(0, 0, 0);


        vehicleCamera.SetActive(true);
        playerCamera.SetActive(false);
     
    }

    public void TaskExitOnClick()
    {

        player.SetActive(true);
        dockedBoat.SetActive(true);
        boat.SetActive(false);

        player.transform.parent = playerDropOffPoint;
        player.transform.localPosition = Vector3.zero;
        boat.transform.rotation = Quaternion.Euler(0, 0, 0);



        vehicleCamera.SetActive(false);
        playerCamera.SetActive(true);

    }
}
