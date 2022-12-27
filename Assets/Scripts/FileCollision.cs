using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FileCollision : MonoBehaviour
{
    public GameObject mainCamera;

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.name == "Player")
        {
            CameraController cam = mainCamera.GetComponent<CameraController>();
            StartCoroutine(cam.ZoomIn());
        }
    }
}
