using UnityEngine;

public class CloseApp : MonoBehaviour
{
    public void QuitApp()
    {
        // Close the application
        Application.Quit();
        Debug.Log("I guess I'm done playing for now..");
    }
}
