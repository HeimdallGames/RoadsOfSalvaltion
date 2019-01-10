using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

    //public float acel = 50; //Aceleracion //No se usa?
    public float velMin = 10; //Velocidad maxima
    public float velMax = 30; //Velocidad minima
    public float velLateral = 15.0f;

    public string upKey;
    public string downKey;

	public GameObject meta;

    public float InitialPosHorizontal = 0; // El carril donde se encuentra el vehiculo
    private bool goingToCentral = false;

    private Rigidbody rb;
    private Text puntos;
    private int puntuacion; //Almacena la puntuación
	private float posicionInicial;
	private float posicionFinal;
	private float distTotal;

    private float lastZ;
    private float lastCarril;
    
    private bool isAcel=false;
    private bool isFren=false;
    void Start()
    {
        AudioManager.instance.Play("MotorVehicle");
        InitialPosHorizontal = (float) System.Math.Round(transform.position.z, 2); 
        rb = GetComponent<Rigidbody>();
		posicionInicial = transform.position.x;
		posicionFinal = meta.transform.position.x;
		distTotal = Mathf.Abs (posicionFinal - posicionInicial);
        puntos = GameObject.Find("puntosN").GetComponent<Text>(); //Para recoger el texto y poder cambiarlo
        
    }
    
    void FixedUpdate()
    {


        /**************************************************************/
        /******************** CONTROL DE VELOCIDAD ********************/
        /**************************************************************/
        float moveHorizontal = Input.GetAxis("Horizontal"); // Valor entre 1 y -1.
        isAcel = StaticData.isAcel;
        isFren = StaticData.isFren;
        Vector3 velocity = Vector3.zero;

        //Si la velocidad ya es maxima, ignora el input positivo
        if ((moveHorizontal > 0 && rb.velocity.x <= velMax) || isAcel)
        {
            rb.velocity = new Vector3(velMax, rb.velocity.y, rb.velocity.z);
        }
        //Si la velocidad ya es minima, ignora el input negativo. 
        //Ademas, si el objeto no llega a la velocidad minima, se le da (solo ocurre una vez) 
        else if ((moveHorizontal < 0 || rb.velocity.x <= velMin) || isFren)
        {
            rb.velocity = new Vector3(velMin, rb.velocity.y, rb.velocity.z);
        }

        /**************************************************************/
        /* COMPROBACIÓN NO SALE DE CARRETERA Y SE POSICIONA EN CARRIL */
        /**************************************************************/
        //Arriba a medio
        
        if (goingToCentral && transform.position.z < InitialPosHorizontal + 0.2 && transform.position.z > InitialPosHorizontal - 0.2)
        {
            goingToCentral = false;
            rb.position = new Vector3(rb.position.x, rb.position.y, InitialPosHorizontal);
            rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, 0.0f);
        }
        //Medio arriba
        else if (transform.position.z > InitialPosHorizontal + 2.6f)
        {
            rb.position = new Vector3(rb.position.x, rb.position.y, InitialPosHorizontal + 2.5f);
            rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, 0.0f);
        }
        //Medio abajo
        else if (transform.position.z < InitialPosHorizontal - 2.6f)
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
		float avanzado = Mathf.Abs(((transform.position.x - posicionInicial )/distTotal))*8000;
		puntuacion = Mathf.CeilToInt (avanzado);
    }

    private void Update()
    {
        if (Input.GetKeyDown(upKey))
        {
            AudioManager.instance.Play("DeslizamientoLateral1");
            if (transform.position.z < InitialPosHorizontal)
            {
                goingToCentral = true;
            }
            rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, velLateral);
        }
        else if (Input.GetKeyDown(downKey))
        {
            AudioManager.instance.Play("DeslizamientoLateral2");
            if (transform.position.z > InitialPosHorizontal)
            {
                goingToCentral = true;
            }
            rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, -velLateral);
        }

        //Necesario para el control táctil
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved){
            Vector2 desplazamiento = Input.GetTouch(0).deltaPosition;
            if (desplazamiento.y > 1)
            {
                AudioManager.instance.Play("DeslizamientoLateral1");
                if (transform.position.z < InitialPosHorizontal)
                {
                    goingToCentral = true;
                }
                rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, velLateral);
            }
            else if (desplazamiento.y < 1) {
                AudioManager.instance.Play("DeslizamientoLateral2");
                if (transform.position.z > InitialPosHorizontal)
                {
                    goingToCentral = true;
                }
                rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, -velLateral);
            }
        }
        puntos.text = "" + puntuacion;
    }

    //Cuando el personaje muere
    private void death()
    {
        AudioManager.StopAllAudio();
        AudioManager.instance.Play("Atropello3");
        StaticData.punctuation = puntuacion;
        StaticData.lastScenario = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene("gameOverScene");
    }

    private void nextLevel()
    {
        AudioManager.StopAllAudio();
        StaticData.punctuation = puntuacion;
        StaticData.lastScenario = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene("nextLevelScene");
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
                AudioManager.instance.Play("Coleccionable");
                break;
            case "vieja":
                Destroy(other.gameObject);
                puntuacion += 30;
                AudioManager.instance.Play("Atropello1");
                break;
            case "goal":
				if (transform.position.x >= posicionFinal)
				{
					int bonus = 500;
					if (Time.time < 100) {
						bonus = 2000;
					} else if (Time.time < 130) {
						bonus = 1500;
					} else if (Time.time < 160) {
						bonus = 1000;
					}
					puntuacion += bonus;
				}
                Debug.Log("NEXT LEVEL");
                nextLevel();
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
