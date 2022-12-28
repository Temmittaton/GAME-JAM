using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingScript : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    private bool isCloned = false;
    [SerializeField] private GameObject cam;
    private bool isStopped = false;
    

    // Start is called before the first frame update
    void Start()
    {
        isCloned = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(cam.GetComponent<CameraIntro>().isStopped == false)
        {
            switch(gameObject.tag)
            {
            case "building":
                Clone(-12f, -6.9f, 31f, -33f, 0f);
                break;
            case "street":
                Clone(-10f, -10f, 35f, -42f, -3f);
                break;
            }
        }
        else
        {
            if(isStopped == false)
            {
                StartCoroutine(Stop());
            }
        }
    }

    IEnumerator Stop()
    {
        isStopped = true;
        while(rb.velocity.x <= 0)
        {
            rb.velocity += new Vector2(0.15f, 0f);
            yield return new WaitForSeconds(0.01f);
        }
        rb.velocity = Vector3.zero;
    }

    void Clone(float speed, float maxX, float cloneX, float destroyX, float cloneY)
    {
        rb.velocity = new Vector2(speed,0);
        if(transform.position.x < maxX && isCloned == false)
        {
            isCloned = true;
            Instantiate(gameObject, new Vector3(cloneX,cloneY,0), Quaternion.identity);
        }
        if(transform.position.x < destroyX)
        {
            Destroy(gameObject);
        }
    }
}
