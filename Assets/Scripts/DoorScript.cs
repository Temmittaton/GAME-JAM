using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject door;
    public bool isOpen = false;
    

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(gameObject.tag == "door")
        {
            if(transform.position.x - player.transform.position.x < 0.5f && transform.position.x - player.transform.position.x > -3f)
            {
                isOpen = true;
            }
            else
            {
                isOpen = false;
            } 
        }
        else
        {
            if(door.GetComponent<DoorScript>().isOpen == true)
            {
                if(gameObject.tag == "open")
                {
                    gameObject.GetComponent<SpriteRenderer>().enabled = true;
                }
                else
                {
                    gameObject.GetComponent<SpriteRenderer>().enabled = false;
                }
            }
            else
            {
                if(gameObject.tag == "closed")
                {
                    gameObject.GetComponent<SpriteRenderer>().enabled = true;
                }
                else
                {
                    gameObject.GetComponent<SpriteRenderer>().enabled = false;
                } 
            }
        }

    }
}
