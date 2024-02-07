using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : MonoBehaviour
{
    public float playerSpeed = 15f;

    private Rigidbody playerRb;
    private float playerJumpHeight = 9f;
    private bool isGrounded = false;

    private void Awake()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void ProcessMove(Vector2 input)
    {
        Vector3 movementVector = Vector3.zero;
        movementVector = transform.forward * input.y + transform.right * input.x;
        transform.position += playerSpeed * Time.deltaTime * movementVector.normalized;
    }

    public void Jump()
    {
        if (isGrounded)
        {
            playerRb.AddForce(Vector3.up * playerJumpHeight, ForceMode.Impulse);
            isGrounded = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }
        else if (collision.gameObject.tag == "Deathzone")
        {
            transform.position = new Vector3(0, 1.5f, 0);
        }
    }
}
