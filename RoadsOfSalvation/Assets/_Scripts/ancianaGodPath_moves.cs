using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ancianaGodPath_moves : MonoBehaviour {
    private Vector3 start;
    private Vector3 nueva;

    private float vel = 0.5f;
    private float maxDist = 0.007f;

    private string escena;

    void Start () {
        AudioManager.instance.Play("Vieja");
        escena = SceneManager.GetActiveScene().name;
        start = transform.localPosition;
        nueva = transform.localPosition;
        escena = SceneManager.GetActiveScene().name;

        if (escena.Equals("GodPath_1"))
        {
            maxDist = 2.25f;
        }
        else if (escena.Equals("GodPath_2"))
        {
            maxDist = 0.007f;
        }
    }
	
	// Update is called once per frame
	void Update () {
        if (escena.Equals("GodPath_1"))
        {
            if (start.z == 0)
            {
                nueva.z = start.z + (maxDist * Mathf.Sin(Time.time * vel * 2));
                transform.localPosition = nueva;
            }
            else if (start.z == maxDist)
            {

                nueva.z = start.z - ((maxDist * 2) * Mathf.Abs(Mathf.Sin(Time.time * vel)));
                transform.localPosition = nueva;

            }
            else if (start.z == -maxDist)
            {

                nueva.z = start.z + ((maxDist * 2) * Mathf.Abs(Mathf.Sin(Time.time * vel)));
                transform.localPosition = nueva;
            }
        }
        else if (escena.Equals("GodPath_2"))
        {
            if (start.y == 0)
            {
                nueva.y = start.y + (maxDist * Mathf.Sin(Time.time * vel * 2));
                transform.localPosition = nueva;
            }
            else if (start.y == maxDist)
            {

                nueva.y = start.y - ((maxDist * 2) * Mathf.Abs(Mathf.Sin(Time.time * vel)));
                transform.localPosition = nueva;

            }
            else if (start.y == -maxDist)
            {

                nueva.y = start.y + ((maxDist * 2) * Mathf.Abs(Mathf.Sin(Time.time * vel)));
                transform.localPosition = nueva;
            }
        }
        
	}
}
