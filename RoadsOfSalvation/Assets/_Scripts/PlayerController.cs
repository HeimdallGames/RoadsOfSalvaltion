using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerController : MonoBehaviour
{

    public float acel; //Aceleracion
    public float velMin; //Velocidad maxima
    public float velMax; //Velocidad minima

    public string upKey;
    public string downKey;

    private int posHorizontal = 0; // El carril donde se encuentra el vehiculo
    private Rigidbody rb;
    private Text puntos;
    private int puntuacion; //Almacena la puntuación
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        puntos = GameObject.Find("puntosN").GetComponent<Text>(); //Para recoger el texto y poder cambiarlo
    }


    void FixedUpdate()
    {

        float moveHorizontal = Input.GetAxis("Horizontal"); // Valor entre 1 y -1.
        Vector3 velocity=Vector3.zero;

        //Si la velocidad ya es maxima, ignora el input positivo
        if (moveHorizontal > 0 && rb.velocity.x <= velMax)
        {
            velocity = new Vector3(velMax, rb.velocity.y, 0.0f);
        }
        //Si la velocidad ya es minima, ignora el input negativo. 
        //Ademas, si el objeto no llega a la velocidad minima, se le da (solo ocurre una vez) 
        else if (moveHorizontal < 0 || rb.velocity.x <= velMin)
        {
            velocity = new Vector3(velMin, rb.velocity.y, 0.0f);
        }

        

        rb.velocity = velocity;

        puntuacion += 1;

    }

    private void Update()
    {
        if (Input.GetKeyDown(upKey) && posHorizontal < 1)
        {
            print("Parriba");
            posHorizontal += 1;
            rb.AddForce(0, 0, 150,ForceMode.VelocityChange);
            //rb.MovePosition(transform.position + (Vector3.forward * 3));
        }
        else if (Input.GetKeyDown(downKey) && posHorizontal > -1)
        {
            print("Pabajo");
            posHorizontal -= 1;
            rb.AddForce(0, 0, -150, ForceMode.VelocityChange);
           // rb.MovePosition(transform.position + (Vector3.back * 3));
        }

        puntos.text = ""+puntuacion;
    }

    private void OnTriggerEnter(Collider other)
    {

        switch (other.tag) {
            case "finish":
                break;
            case "puntos":
                Destroy(other.gameObject);
                puntuacion += 30;
                break;
            default:
                break;

        }
    }
}

