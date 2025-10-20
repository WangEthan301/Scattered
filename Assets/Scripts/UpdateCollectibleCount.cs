using UnityEngine;
using TMPro;
using System;
using UnityEngine.SceneManagement;

public class UpdateCollectibleCount : MonoBehaviour
{
    private TextMeshProUGUI counterText;

    void Start()
    {
        counterText = GetComponent<TextMeshProUGUI>();
        UpdateUI(); // Update when the scene starts
    }

    public void UpdateUI()
    {
        if (GameManager.Instance == null) return;

        int total2D = GameManager.Instance.totalCollectibles2D;
        int total3D = GameManager.Instance.totalCollectibles3D;
        int collected2D = GameManager.Instance.collected2D;
        int collected3D = GameManager.Instance.collected3D;

        int remaining2D = Math.Max(0,total2D - collected2D);
        int remaining3D = Math.Max(0,total3D - collected3D);

        counterText.text = $"2D Remaining: {remaining2D}\n3D Remaining: {remaining3D}";

        if(remaining2D == 0 && remaining3D == 0)
        {

            SceneManager.LoadScene("Credits");
        }
    }
}
