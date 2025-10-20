using UnityEngine;

public class Respawn3D : MonoBehaviour
{
    public Vector3 respawnPoint = new Vector3(0, 1, 0); // origin position

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            // Move player back to respawn
            transform.position = respawnPoint;
        }
    }
}
