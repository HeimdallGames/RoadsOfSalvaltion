using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

    public float acel; //Aceleracion
    public float velMin; //Velocidad maxima
    public float velMax; //Velocidad minima
    public float velLateral = 15.0f;

    public string upKey;
    public string downKey;

    public float InitialPosHorizontal = 0; // El carril donde se encuentra el vehiculo
    private bool goingToCentral = false;

    private Rigidbody rb;
    private Text puntos;
    private int puntuacion; //Almacena la puntuación

    private float lastZ;
    private float lastCarril;


    void Start()
    {
        InitialPosHorizontal = (float) System.Math.Round(transform.position.z, 2); 
        rb = GetComponent<Rigidbody>();
        puntos = GameObject.Find("puntosN").GetComponent<Text>(); //Para recoger el texto y poder cambiarlo
    }


    void FixedUpdate()
    {


        /**************************************************************/
        /******************** CONTROL DE VELOCIDAD ********************/
        /**************************************************************/
        float moveHorizontal = Input.GetAxis("Horizontal"); // Valor entre 1 y -1.
        Vector3 velocity = Vector3.zero;

        //Si la velocidad ya es maxima, ignora el input positivo
        if (moveHorizontal > 0 && rb.velocity.x <= velMax)
        {
            rb.velocity = new Vector3(velMax, rb.velocity.y, rb.velocity.z);
        }
        //Si la velocidad ya es minima, ignora el input negativo. 
        //Ademas, si el objeto no llega a la velocidad minima, se le da (solo ocurre una vez) 
        else if (moveHorizontal < 0 || rb.velocity.x <= velMin)
        {
            rb.velocity = new Vector3(velMin, rb.velocity.y, rb.velocity.z);
        }

        /**************************************************************/
        /* COMPROBACIÓN NO SALE DE CARRETERA Y SE POSICIONA EN CARRIL */
        /**************************************************************/
        if (goingToCentral && transform.position.z < InitialPosHorizontal + 0.1 && transform.position.z > InitialPosHorizontal - 0.1)
        {
            goingToCentral = false;
            rb.position = new Vector3(rb.position.x, rb.position.y, InitialPosHorizontal);
            rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, 0.0f);
        }
        else if (transform.position.z > InitialPosHorizontal + 2.5f)
        {
            rb.position = new Vector3(rb.position.x, rb.position.y, InitialPosHorizontal + 2.5f);
            rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, 0.0f);
        }
        else if (transform.position.z < InitialPosHorizontal - 2.5f)
        {
            rb.position = new Vector3(rb.position.x, rb.position.y, InitialPosHorizontal - 2.5f);
            rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, 0.0f);
        }
        /**************************************************************/
        /**************************************************************/
        /**************************************************************/
        /*
         * 
         * Problema de los muros resuelto por ahora haciendo el collider mas grande
         * 
         * */

        puntuacion += 1;

    }

    private void Update()
    {
        if (Input.GetKeyDown(upKey))
        {
            if (transform.position.z < InitialPosHorizontal)
            {
                goingToCentral = true;
            }
            rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, velLateral);
        }
        else if (Input.GetKeyDown(downKey))
        {
            if (transform.position.z > InitialPosHorizontal)
            {
                goingToCentral = true;
            }
            rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, -velLateral);
        }

        puntos.text = "" + puntuacion;
    }

    private void death()
    {
        StaticData.punctuation = puntuacion;
        StaticData.lastScenario = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene("gameOverScene");
    }

    private void OnTriggerEnter(Collider other)
    {

        switch (other.tag)
        {
            case "finish":
                death();
                break;
            case "puntos":
                Destroy(other.gameObject);
                puntuacion += 30;
                break;
            default:
                break;

        }
    }

    void OnCollisionEnter(Collision collision)
    {
        switch (collision.collider.tag)
        {
            case "finish":
                death();
                break;
        }
            
    }
}
