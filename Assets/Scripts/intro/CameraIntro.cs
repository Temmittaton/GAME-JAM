using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraIntro : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private GameObject street;
    public bool isStopped = false;

    // Start is called before the first frame update
    void Start()
    {
        speed = 0.1f;
        gameObject.GetComponent<Camera>().orthographicSize = 0.1f;
        transform.position = new Vector3(0,15f,-10f);
        StartCoroutine(Intro());
    }

    IEnumerator Intro()
    {
        yield return new WaitForSeconds(0.1f);

        for(int i = 0; i < 50; i++)
        {
            gameObject.GetComponent<Camera>().orthographicSize += 0.1f;
            yield return new WaitForSeconds(0.01f);
        }
        
        yield return new WaitForSeconds(1f);

        var t = 0.0f;
        while(transform.position.y + 1f > 0.1f)
        {
            t += Time.deltaTime * speed;
            transform.position = Vector3.Lerp(transform.position, new Vector3(0f,-1f,-10f), t);
            yield return new WaitForSeconds(0.01f);
        }

        yield return new WaitForSeconds(2f);

        isStopped = true;

        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("Office");
    }
}
