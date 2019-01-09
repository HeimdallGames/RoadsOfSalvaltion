using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Perseguidor : MonoBehaviour {

    public GameObject objectoLanzado;
    public float frecuenciaLanzamiento = 4;
    public float inicioLanzamientos = 4;


	// Use this for initialization
	void Start () {
        InvokeRepeating("Lanzamiento", inicioLanzamientos, frecuenciaLanzamiento);
	}
	
    void Lanzamiento()
    {
        float distExtraLmao;
        if (transform.parent.name == "personaje_bueno")
        {
            distExtraLmao = 2;
        }
        else
        {
            distExtraLmao = 1;
        }
        GameObject obj = Instantiate(objectoLanzado, new Vector3(transform.position.x, transform.position.y+ distExtraLmao, transform.position.z), transform.rotation);
        obj.tag = "finish";
        obj.AddComponent<moveForwardConstantly>();
    }
        
}
