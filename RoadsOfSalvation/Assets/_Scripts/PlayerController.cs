using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float acel = 100.0f; //Aceleracion
    public float velMin = 300.0f; //Velocidad maxima
    public float velMax = 600.0f; //Velocidad minima

    public string upKey = "w";
    public string downKey = "s";

    private int posHorizontal = 0; // El carril donde se encuentra el vehiculo
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
        if (moveHorizontal > 0 && rb.velocity.x <= velMax)
        {
            rb.velocity = new Vector3(velMax, rb.velocity.y, 0.0f);
        }
        //Si la velocidad ya es minima, ignora el input negativo. 
        //Ademas, si el objeto no llega a la velocidad minima, se le da (solo ocurre una vez) 
        else if (moveHorizontal < 0 || rb.velocity.x <= velMin)
        {
            rb.velocity = new Vector3(velMin, rb.velocity.y, 0.0f);
        }


    }
    private void Update()
    {
        if (Input.GetKeyDown(upKey) && posHorizontal < 1)
        {
            print("Parriba");
            posHorizontal += 1;
            rb.MovePosition(transform.position + (Vector3.forward * 3));
        }
        else if (Input.GetKeyDown(downKey) && posHorizontal > -1)
        {
            print("Pabajo");
            posHorizontal -= 1;
            rb.MovePosition(transform.position + (Vector3.back * 3));


        }
    }
}

