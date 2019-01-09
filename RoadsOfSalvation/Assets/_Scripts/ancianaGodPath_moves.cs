using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ancianaGodPath_moves : MonoBehaviour {
    private Vector3 start;
    private Vector3 nueva;

    private float vel = 0.5f;
    private float maxDist = 0.007f;

    void Start () {
        start = transform.localPosition;
        nueva = transform.localPosition;
	}
	
	// Update is called once per frame
	void Update () {
        if (start.y == 0)
        {
            nueva.y = start.y + (maxDist * Mathf.Sin(Time.time * vel));
            transform.localPosition = nueva;
        }
        else if (start.y == maxDist)
        {
           
            nueva.y = start.y - ((maxDist*2) * Mathf.Abs(Mathf.Sin(Time.time * vel)));
            transform.localPosition = nueva;

        }
        else if (start.y == -maxDist) {
            
            nueva.y = start.y + ((maxDist*2) * Mathf.Abs(Mathf.Sin(Time.time * vel)));
            transform.localPosition = nueva;
        }
	}
}
