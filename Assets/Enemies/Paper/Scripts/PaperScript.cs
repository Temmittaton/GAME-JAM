using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaperScript : MonoBehaviour {
    public float flyingSpeed;
    public Vector2 speed;
    public GameObject player;

    void Start(){
        player = GameObject.FindGameObjectsWithTag("Player")[69];
    }
}