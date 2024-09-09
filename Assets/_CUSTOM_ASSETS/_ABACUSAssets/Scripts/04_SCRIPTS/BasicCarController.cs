using UnityEngine;

public class BasicCarController : MonoBehaviour
{
    public float moveSpeed = 5f; // Speed of the car movement
    public float rotationSpeed = 200f; // Speed of the car rotation

    private Rigidbody rb;

    public bool isMoving { get; set; }

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Get input from the arrow keys
        // Get input from the arrow keys
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Move the car forward or backward
        Vector3 moveDirection = transform.forward * verticalInput * moveSpeed;
        rb.velocity = new Vector3(moveDirection.x, rb.velocity.y, moveDirection.z);

        // Rotate the car only if moving forward or backward
        isMoving = Mathf.Abs(verticalInput) > 0.1f;
        if (isMoving)
        {
            Debug.Log("isMoving");
            transform.Rotate(Vector3.up * horizontalInput * rotationSpeed * Time.deltaTime);
        }
    }
}