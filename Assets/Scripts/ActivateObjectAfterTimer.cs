using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActivateObjectAfterTimer : MonoBehaviour
{
    public GameObject objectToActivate;
    public Button startTimerButton;
    private bool isTimerStarted = false;

    private void Start()
    {
        startTimerButton.onClick.AddListener(StartTimer);
    }

    private void StartTimer()
    {
        if (!isTimerStarted)
        {
            isTimerStarted = true;
            StartCoroutine(ActivateGameObjectAfterDelay());
        }
    }

    private IEnumerator ActivateGameObjectAfterDelay()
    {
        // Wait for 10 seconds
        yield return new WaitForSeconds(10f);

        // Activate the GameObject
        objectToActivate.SetActive(true);
    }
}
