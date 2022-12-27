using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraController : MonoBehaviour
{
    public Camera mainCamera;
    public GameObject player;
    public GameObject fileCol;

    void Start()
    {
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y + 1f, transform.position.z);
    }


    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.X))
        {
            StartCoroutine(ZoomIn());
        }

        transform.position = new Vector3(player.transform.position.x, transform.position.y, transform.position.z);

        if(transform.position.y - player.transform.position.y < 0f) 
        {
            transform.position = new Vector3(transform.position.x, player.transform.position.y, transform.position.z);
        }
        else
        {
            if(transform.position.y - player.transform.position.y > 2.5f)
            {
                transform.position = new Vector3(transform.position.x, player.transform.position.y + 2.5f, transform.position.z);
            }
        }
    }

    public IEnumerator ZoomIn()
    {
        var t = 0.0;
        while(t<1.0)
        {
            t += Time.deltaTime * 20f;
            transform.position = Vector3.Lerp(transform.position, fileCol.transform.position, Time.deltaTime * 20f);
            yield return 0;
        }

        for(int i = 0; i < 25; i++)
        {
            mainCamera.orthographicSize -= 0.1f;
            yield return new WaitForSeconds(0.02f);
        }

        SceneManager.LoadScene(fileCol.name);
    }

}
