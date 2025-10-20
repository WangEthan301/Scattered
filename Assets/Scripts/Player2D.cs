using UnityEngine;

public class Player2D : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float moveSpeed = 0.5f;
    private Rigidbody2D rb;
    private Vector2 movement;
    void Start()
    {

        rb = GetComponent<Rigidbody2D>();
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        movement.x = horizontalInput;
        movement.y = verticalInput;

        movement = new Vector2(horizontalInput, verticalInput).normalized;
    }

    private void FixedUpdate()
    {
        Vector2 newPos = rb.position + movement * moveSpeed * Time.fixedDeltaTime;
        
        rb.MovePosition(newPos);
    }
}
