using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerUIPanel : MonoBehaviour
{

    public GameObject boatEnterButton;
    public GameObject boatExitButton;

    void Start()
    {
        boatEnterButton.SetActive(false);
        boatExitButton.SetActive(false);
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            boatEnterButton.SetActive(true);
        }
        if (collision.gameObject.tag == "Boat")
        {
            boatExitButton.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            boatEnterButton.SetActive(false);
        }
        if (collision.gameObject.tag == "Boat")
        {
            boatExitButton.SetActive(false);
        }
    }

}
