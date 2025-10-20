using UnityEngine;

public class Respawn2D : MonoBehaviour
{
    public Vector2 respawnPoint = new Vector2(0, 0); // origin position

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            // Move player back to respawn
            transform.position = respawnPoint;
        }
    }
}
