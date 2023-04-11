using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerUIPanel : MonoBehaviour
{

    public GameObject boatEnterButton;

    void Start()
    {
        boatEnterButton.SetActive(false);
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            boatEnterButton.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            boatEnterButton.SetActive(false);
        }
    }

}
