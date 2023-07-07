using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPanelTrigger : MonoBehaviour
{

    public GameObject mainMenuPanel;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Menu"))
        {
            mainMenuPanel.SetActive(true);
        }
    }


}
