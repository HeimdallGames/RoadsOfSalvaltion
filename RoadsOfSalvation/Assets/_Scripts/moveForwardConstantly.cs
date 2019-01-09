using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveForwardConstantly : MonoBehaviour {
	
    // Update is called once per frame
    void FixedUpdate () {
        transform.position = new Vector3(transform.position.x+1, transform.position.y, transform.position.z);
        //Destruir objeto si X distancia más del personaje
    }
}
