using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingScreenController : MonoBehaviour
{
    public Animator loadingAnimator; // Reference to the animator controlling the loading animation
    public string targetSceneName; // Name of the scene you want to load

    public void LoadTargetSceneWithAnimation()
    {
        // Start playing the loading animation
        loadingAnimator.Play("LoadingSpin"); // Replace "YourLoadingAnimation" with the name of your loading animation state

        // Load the target scene asynchronously after a short delay (to let the animation play)
        StartCoroutine(LoadTargetSceneAsync());
    }

    private IEnumerator LoadTargetSceneAsync()
    {
        // Wait for a short delay (you can adjust the delay as needed)
        yield return new WaitForSeconds(1.5f);

        // Start loading the target scene asynchronously
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(targetSceneName);

        // Prevent the new scene from automatically activating on completion
        asyncLoad.allowSceneActivation = false;

        // Wait until the scene loading is almost complete
        while (!asyncLoad.isDone)
        {
            // Check if the loading progress is almost complete (0.9 is nearly complete)
            if (asyncLoad.progress >= 0.9f)
            {
                // Allow the new scene to activate
                asyncLoad.allowSceneActivation = true;
            }
            yield return null;
        }
    }
}
