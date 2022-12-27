using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExclamationScript : MonoBehaviour
{
    public AnimationCurve curve;
    private float yPos = -2.8f;

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x, curve.Evaluate((Time.time % curve.length)) + yPos, transform.position.z);
    }
}
