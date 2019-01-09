using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Perseguidor : MonoBehaviour {

    public GameObject objectoLanzado;
    public float frecuenciaLanzamiento = 2;
    public float inicioLanzamientos = 3;


	// Use this for initialization
	void Start () {
        InvokeRepeating("Lanzamiento", inicioLanzamientos, frecuenciaLanzamiento);
	}
	
    void Lanzamiento()
    {
        GameObject obj = Instantiate(objectoLanzado, transform.position, transform.rotation);
        obj.tag = "finish";
        obj.AddComponent<moveForwardConstantly>();
    }
        
}
