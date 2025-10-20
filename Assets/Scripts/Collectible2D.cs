using UnityEngine;

public class Collectible2D : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float rotationSpeed = 0.5f;

    AudioSource audioSource;
    public AudioClip collect;
    // Update is called once per frame

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    void Update()
    {
        transform.Rotate(0,0,rotationSpeed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.CompareTag("Player"))
        {
            audioSource.PlayOneShot(collect);
            GameManager.Instance?.CollectiblePickedUp2D();
            Destroy(gameObject,0.3f);
        }
    }
}
