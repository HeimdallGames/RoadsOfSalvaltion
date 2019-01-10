using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveForwardConstantly : MonoBehaviour {

    private float velocidadProyectil = 40f;

    private void Start()
    {
        GetComponent<Rigidbody>().AddForce(new Vector3(velocidadProyectil, 0, 0), ForceMode.VelocityChange);
        Invoke("Destroy", 4.0f);
    }

    private void Destroy()
    {
        Object.Destroy(gameObject);
    }
}
