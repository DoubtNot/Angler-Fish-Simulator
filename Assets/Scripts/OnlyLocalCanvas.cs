using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class OnlyLocalCanvas : MonoBehaviour
{
    public GameObject canvas;
    PhotonView view;

    void Start()
    {
        view = GetComponent<PhotonView>();

        if (view.IsMine)
        {
            canvas.SetActive(true);
        }
    }
}