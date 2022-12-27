using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player2D : MonoBehaviour {
    public Rigidbody2D rb;
    [SerializeField] int jumpforce;
    [SerializeField] float speed;
    public bool isGrounded = true;
    public GameObject cam;
    public float friction, grav, maxSpeed;
    public Vector2 move;

    public void print(float a){
        Debug.Log(Convert.ToString(a));
    }

    private void OnCollisionEnter2D(Collision2D collision){
        if (collision.gameObject.tag == "floor"){
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision){
        if (collision.gameObject.tag == "floor"){
            isGrounded = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.tag == "file"){
            CameraController camControl = cam.GetComponent<CameraController>();
            camControl.fileCol = collision.gameObject;
        }
    }

    void Update(){
        float axis = Input.GetAxisRaw("Horizontal");

        move.x = Mathf.Clamp((move.x + axis * speed) * friction, -maxSpeed, maxSpeed);

        if (!isGrounded){move.y -= grav;}
        else if (move.y < 0){move.y = 0f;}
        
        rb.velocity = move;

        if(Input.GetKeyDown(KeyCode.Space) && isGrounded){
            rb.AddForce(Vector2.up * jumpforce, ForceMode2D.Impulse);
            isGrounded = false;
        }
    }
}
