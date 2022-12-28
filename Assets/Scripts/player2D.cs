using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player2D : MonoBehaviour
{
    public Rigidbody2D rb;
    [SerializeField] float speed = 500f;
    [SerializeField] int jumpforce = 5;
    private bool isGrounded = false;
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
            StartCoroutine(reCheckCol());
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

    IEnumerator reCheckCol()
    {
        gameObject.GetComponent<CapsuleCollider2D>().enabled = false;
        yield return 0;
        gameObject.GetComponent<CapsuleCollider2D>().enabled = true;
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

        if(axis == 0 && Input.GetKey(KeyCode.Space) == false && isGrounded == true)
        {
            rb.velocity = new Vector2(0f, 0f);
            rb.gravityScale = 0f;
        }
        else
        {
            rb.gravityScale = 1f;
        }
    }
}
