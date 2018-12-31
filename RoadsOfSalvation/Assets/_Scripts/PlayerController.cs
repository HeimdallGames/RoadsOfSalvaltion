using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float acel = 100.0f; //Aceleracion
    public float velMin = 10.0f; //Velocidad maxima
    public float velMax = 30.0f; //Velocidad minima

    public string upKey = "w";
    public string downKey = "s";

    private Rigidbody rb;

    Vector3 movement;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal"); // Valor entre 1 y -1.

        //Si la velocidad ya es maxima, ignora el input positivo
        if(moveHorizontal>0 && rb.velocity.x >= velMax)
        {
            rb.velocity = new Vector3(velMax, rb.velocity.y, 0.0f);
        }
        //Si la velocidad ya es minima, ignora el input negativo. 
        //Ademas, si el objeto no llega a la velocidad minima, se le da (solo ocurre una vez) 
        else if (moveHorizontal <= 0 && rb.velocity.x <= velMin)
        {
            rb.velocity = new Vector3(velMin, rb.velocity.y, 0.0f);
        }
        //Caso normal en el que la aceleracion/deceleracion depende del input
        else if (moveHorizontal != 0)
        {
            movement = new Vector3(moveHorizontal * acel, 0.0f, 0.0f);
            rb.AddForce(movement);
        }
        
    }

    private void Update()
    {
        if (Input.GetKeyDown(upKey))
        {
            print("Parriba");
            //temporal y no funsiona
            if(transform.position.x < 0)
                transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + 2.5f);
        }
        else if (Input.GetKeyDown(downKey))
        {
            print("Pabajo");
            //temporal y no funsiona
            if (transform.position.x < -5)
                transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 2.5f);
        }
    }
}

