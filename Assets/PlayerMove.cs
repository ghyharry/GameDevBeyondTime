using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float moveSpeed = 5f; // Speed at which the player moves
    public float jumpForce = 25f; // Force of the jump

    private Rigidbody2D rb; // Reference to the Rigidbody2D component
    private bool isGrounded = true; // Check if the player is grounded

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Get the Rigidbody2D component attached to the player
    }

    // Update is called once per frame
    void Update()
    {
        // Move left or right
        float move = Input.GetAxis("Horizontal"); // Get the horizontal input (A/D or Left Arrow/Right Arrow)
        transform.position += new Vector3(move, 0, 0) * moveSpeed * Time.deltaTime;

        // Jump
        if (Input.GetButtonDown("Jump") && isGrounded) // Check if the jump button is pressed and the player is grounded
        {
            rb.AddForce(new Vector2(0, jumpForce)); // Add an upward force to the Rigidbody2D
        }
    }

    // // Check if the player is touching the ground
    // private void OnCollisionEnter2D(Collision2D collision)
    // {
    //     if (collision.gameObject.CompareTag("Ground")) // Make sure the ground objects have a tag "Ground"
    //     {
    //         isGrounded = true; // The player is grounded
    //     }
    // }

    // private void OnCollisionExit2D(Collision2D collision)
    // {
    //     if (collision.gameObject.CompareTag("Ground"))
    //     {
    //         isGrounded = false; // The player is not grounded
    //     }
    // }
}
