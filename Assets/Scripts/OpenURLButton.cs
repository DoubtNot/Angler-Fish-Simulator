using UnityEngine;

public class OpenURLButton : MonoBehaviour
{
    [SerializeField]
    private string url = "https://www.example.com"; // Default URL, you can change it in the Inspector

    public void OpenURL()
    {
        Application.OpenURL(url);
    }
}
