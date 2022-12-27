using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player2D : MonoBehaviour {
    public Rigidbody2D rb;
    [SerializeField] int jumpForce;
    [SerializeField] float speed;
    public bool isGrounded = true;
    public GameObject cam;
    public float friction, grav, maxSpeed, d;
    public Vector2 move;
    public LayerMask groundMask;

    public void print(float a){
        Debug.Log(Convert.ToString(a));
    }

    public bool CheckGround(){
        Debug.DrawRay(transform.position, Vector2.down, Color.red);
        return Physics.Raycast(transform.position, Vector2.down, d, groundMask);
    }

    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.tag == "file"){
            CameraController camControl = cam.GetComponent<CameraController>();
            camControl.fileCol = collision.gameObject;
        }
    }

    void Update(){
        isGrounded = CheckGround();

        float axis = Input.GetAxisRaw("Horizontal");

        move.x = Mathf.Clamp((move.x + axis * speed) * friction, -maxSpeed, maxSpeed);

        if (!isGrounded){move.y -= grav;}
        else {move.y = 0f;}
        
        rb.velocity = move;

        if(Input.GetKeyDown(KeyCode.Space) && isGrounded){
            move.y = jumpForce;
            isGrounded = false;
        }
    }
}
