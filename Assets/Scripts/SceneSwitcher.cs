using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    void Update()
    {
        // Press F1 to toggle between 2D and 3D scenes
        if (Input.GetKeyDown(KeyCode.I))
        {
            string currentScene = SceneManager.GetActiveScene().name;

            if (currentScene == "Scene 2D")
            {
                if (GameManager.Instance.collected2D == 3 || GameManager.Instance.collected2D == 0)
                {
                    SceneManager.LoadScene("Scene 3D");
                }
            }
            else if (currentScene == "Scene 3D")
            {
                if (GameManager.Instance.collected3D == 3 || GameManager.Instance.collected3D == 0)
                {
                    SceneManager.LoadScene("Scene 2D");
                }
            }
        }
    }
}
