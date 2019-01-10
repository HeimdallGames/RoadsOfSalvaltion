using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class pauseController : MonoBehaviour {
    GameObject[] pauseItems;
    Button playB;
    Button resetB;
    Button exitB;
    Button pauseB;
	// Use this for initialization
	void Start () {
        Time.timeScale = 1;
        pauseItems = GameObject.FindGameObjectsWithTag("pausa");
        playB = GameObject.Find("botonPlay").GetComponent<Button>();
        resetB = GameObject.Find("botonReset").GetComponent<Button>();
        exitB = GameObject.Find("botonExit").GetComponent<Button>();
        pauseB = GameObject.Find("botonPause").GetComponent<Button>();

        playB.onClick.AddListener(hide);
        resetB.onClick.AddListener(reset);
        exitB.onClick.AddListener(exit);
        pauseB.onClick.AddListener(show);
        hide();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.P) || Input.GetKey(KeyCode.Escape)) {
            if (Time.timeScale == 1)
            {
                show();
            }
            else if (Time.timeScale == 0) {
                hide();
            }
        }
	}
    //Muestra el menu de pausa
    public void show() {
        Time.timeScale = 0;
        foreach (GameObject g in pauseItems)
        {
            g.SetActive(true);
        }
    }
    //Oculta el menu de pausa
    public void hide() {
        Time.timeScale = 1;
        foreach (GameObject g in pauseItems) {
            g.SetActive(false);
        }
    }
    //Reinicia el nivel actual
    public void reset()
    {
        AudioManager.StopAllAudio();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    //Vuelve al menu principal
    public void exit() {
        AudioManager.StopAllAudio();
        SceneManager.LoadScene("mainMenuScene");
    }
}
