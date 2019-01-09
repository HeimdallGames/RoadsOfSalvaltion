using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ancianaSatanPath_moves : MonoBehaviour {

    private Vector3 start;
    private Vector3 nueva;

    private float vel = 0.5f;
    private float maxDist = 0.05f;

    void Start()
    {
        start = transform.localPosition;
        nueva = transform.localPosition;
    }

    // Update is called once per frame
    void Update () {
        if (start.y == -0.025f)
        {
            Debug.Log("1");
            nueva.y = start.y + ((maxDist/2) * Mathf.Sin(Time.time * vel*2));
            transform.localPosition = nueva;
        }
        else if (start.y == 0)
        {

            Debug.Log("2");
            nueva.y = start.y - (maxDist  * Mathf.Abs(Mathf.Sin(Time.time * vel)));
            transform.localPosition = nueva;

        }
        else if (start.y == -maxDist)
        {

            Debug.Log("3");
            nueva.y = start.y + (maxDist * Mathf.Abs(Mathf.Sin(Time.time * vel)));
            transform.localPosition = nueva;
        }
    }
}

