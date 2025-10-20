using UnityEngine;

public class Collectible3D : MonoBehaviour
{
    public float rotationSpeed = 45f; // degrees per second

    public AudioClip collect;
    AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        // Spin around the Y axis (looks better in 3D than Z)
        transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            audioSource.PlayOneShot(collect);
            GameManager.Instance?.CollectiblePickedUp3D();
            Destroy(gameObject, 0.3f);
        }
    }
}
