using UnityEngine;

public class AudioStart : MonoBehaviour
{
    public AudioSource audioSource;
    public float loopStart = 7f;
    public float loopEnd = 150f;

    void Start()
    {
        audioSource.time = loopStart;
        audioSource.Play();
    }

    void Update()
    {
        if (audioSource.time >= loopEnd)
        {
            audioSource.time = loopStart;
        }
    }
}
