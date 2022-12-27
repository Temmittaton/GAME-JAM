using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextScript : MonoBehaviour
{
    [SerializeField] private Text txt;
    public string[] dialogue;
    public int txtID;
    public bool isStarted = false;

    void Start()
    {
        txt.text = "";
        txtID = -1;
        txt.enabled = false;
        dialogue = new string[] {"Hello there", "Test", "Placeholder","*", "Hahaha", "*"};

    }

    public IEnumerator Dialogue(float interval)
    {
        isStarted = true;

        txt.text = "";
        txt.enabled = true;
        for(int i = 0; i < dialogue[txtID].Length; i++)
        {
            txt.text += dialogue[txtID][i];
            yield return new WaitForSeconds(interval);
        }

        isStarted = false;
    }
}
