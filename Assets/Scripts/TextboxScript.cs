using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextboxScript : MonoBehaviour
{
    [SerializeField] private GameObject txt;

    void Start()
    {
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        TextScript txtScr = txt.GetComponent<TextScript>();

        if(Input.GetKeyDown(KeyCode.Z) && txtScr.isStarted == false)
        {
            txtScr.txtID++;
            if(txtScr.dialogue[txtScr.txtID] != "*")
            {
                Show();
            }
            else
            {
                Hide();
            }
        }
    }


    void Show()
    {
        gameObject.GetComponent<SpriteRenderer>().enabled = true;

        TextScript txtScr = txt.GetComponent<TextScript>();
        StartCoroutine(txtScr.Dialogue(0.1f));
    }

    void Hide()
    {
       gameObject.GetComponent<SpriteRenderer>().enabled = false; 

        txt.GetComponent<Text>().enabled = false;
    }
}
