using System.Collections;
using UnityEngine;

public class LightningLight : MonoBehaviour
{
    public float minSeconds = 5f;   // Minimum interval between flashes
    public float maxSeconds = 15f;  // Maximum interval between flashes
    public float flashDuration = 0.2f; // How long the light stays on

    private Light pointLight;

    private void Start()
    {
        pointLight = GetComponent<Light>();
        pointLight.enabled = false;
        StartCoroutine(FlashLight());
    }

    private IEnumerator FlashLight()
    {
        while (true)
        {
            // Wait random interval
            float waitTime = Random.Range(minSeconds, maxSeconds);
            yield return new WaitForSeconds(waitTime);

            // Turn light on
            pointLight.enabled = true;

            // Wait flash duration
            yield return new WaitForSeconds(flashDuration);

            // Turn light off
            pointLight.enabled = false;
        }
    }
}
