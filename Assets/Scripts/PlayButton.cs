using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class PlayButton : MonoBehaviour
{
    public float delaySeconds;
    // This function will be called when the button is clicked

    public IEnumerator Delay(float waitSeconds)
    {
        yield return new WaitForSeconds(waitSeconds);
    }
    public void OnPlayButtonClicked()
    {
        Delay(delaySeconds);
        SceneManager.LoadScene("Memory Match"); // Make sure this scene is added to Build Settings
    }


}
