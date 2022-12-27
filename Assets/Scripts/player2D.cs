using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player2D : MonoBehaviour
{
    public Rigidbody2D rb;
    [SerializeField] float speed = 500f;
    [SerializeField] int jumpforce = 5;
    private bool isGrounded = true;
    private float axis;
    private Vector2 movement;
    public GameObject cam;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "floor")
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "floor")
        {
            isGrounded = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "file")
        {
            CameraController camControl = cam.GetComponent<CameraController>();
            camControl.fileCol = collision.gameObject;
        }
    }

    // Update is called once per frame
    void Update()
    {
        axis = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(axis * speed, rb.velocity.y);

        if(Input.GetKeyDown(KeyCode.Space)&& isGrounded)
        {
            rb.AddForce(Vector2.up * jumpforce, ForceMode2D.Impulse);
            isGrounded = false;
        }
    }
}
