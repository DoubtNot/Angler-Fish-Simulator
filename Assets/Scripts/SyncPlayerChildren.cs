using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;


public class SyncPlayerChildren : MonoBehaviour
{



    public GameObject childCannon;
    public GameObject childFishingPole;
    public GameObject childBoat;


    PhotonView view;


    void Awake()
    {
        view = GetComponent<PhotonView>();
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
