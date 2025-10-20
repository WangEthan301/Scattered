using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int collected2D = 0;
    public int collected3D = 0;

    public int totalCollectibles2D = 3;
    public int totalCollectibles3D = 3;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Keep between scenes
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Called by 2D collectibles
    public void CollectiblePickedUp2D()
    {
        collected2D++;
        UpdateAllCounters();
    }

    // Called by 3D collectibles
    public void CollectiblePickedUp3D()
    {
        collected3D++;
        UpdateAllCounters();
    }

    // Updates all counters currently active in the scene
    private void UpdateAllCounters()
    {
        UpdateCollectibleCount[] counters = FindObjectsByType<UpdateCollectibleCount>(FindObjectsSortMode.None);
        foreach (var counter in counters)
        {
            counter.UpdateUI();
        }
    }

    // Scene switching
    public void Load2D()
    {
        SceneManager.LoadScene("Scene 2D"); // ✅ your actual scene name
    }

    public void Load3D()
    {
        SceneManager.LoadScene("Scene 3D"); // ✅ your actual scene name
    }
}
