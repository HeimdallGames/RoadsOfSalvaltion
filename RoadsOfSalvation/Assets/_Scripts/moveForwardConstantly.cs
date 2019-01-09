using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveForwardConstantly : MonoBehaviour {
    

    private void Start()
    {
        GetComponent<Rigidbody>().AddForce(new Vector3(15f, 0, 0), ForceMode.VelocityChange);
    }

    // Update is called once per frame
    void FixedUpdate () {
        //Debug.Log(rb.velocity);
        //Destruir objeto si X distancia más del personaje
    }
}
