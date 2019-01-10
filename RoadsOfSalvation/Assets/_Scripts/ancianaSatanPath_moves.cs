using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ancianaSatanPath_moves : MonoBehaviour {

    private Vector3 start;
    private Vector3 nueva;

    private float vel = 0.5f;
    private float maxDist = 0;
    private string escena;
    void Start()
    {
        AudioManager.instance.Play("Vieja");
        escena = SceneManager.GetActiveScene().name;
        start = transform.localPosition;
        nueva = transform.localPosition;

        if (escena.Equals("SatanPath_1"))
        {
            maxDist = 0.05f;
        }
        else if (escena.Equals("SatanPath_2"))
        {
            maxDist = 2.5f;
        }
    }

    // Update is called once per frame
    void Update () {
        //Movimiento en satan path 1
        if (escena.Equals("SatanPath_1"))
        {
            if (start.y == -0.025f)
            {
                nueva.y = start.y + ((maxDist / 2) * Mathf.Sin(Time.time * vel * 2));
                transform.localPosition = nueva;
            }
            else if (start.y == 0)
            {
                nueva.y = start.y - (maxDist * Mathf.Abs(Mathf.Sin(Time.time * vel)));
                transform.localPosition = nueva;

            }
            else if (start.y == -maxDist)
            {
                nueva.y = start.y + (maxDist * Mathf.Abs(Mathf.Sin(Time.time * vel)));
                transform.localPosition = nueva;
            }
        }
        //Movimiento en satanpath 2
        else if (escena.Equals("SatanPath_2")) {
            if (start.z == -2.5f)
            {
                nueva.z = start.z + ((maxDist) * Mathf.Sin(Time.time * vel * 2));
                transform.localPosition = nueva;
            }
            else if (start.z == 0)
            {
                nueva.z = start.z - ((2*maxDist) * Mathf.Abs(Mathf.Sin(Time.time * vel)));
                transform.localPosition = nueva;

            }
            else if (start.z == -5)
            {
                nueva.z = start.z + ((2*maxDist) * Mathf.Abs(Mathf.Sin(Time.time * vel)));
                transform.localPosition = nueva;
            }
        }
    }
}

