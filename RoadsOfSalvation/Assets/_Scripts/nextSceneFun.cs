using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class nextSceneFun : MonoBehaviour {
    private Button next1;
    private Button next2;
    private Button reset;
    private Button exit;
    private string lastScene;
	void Start () {
        reset = GameObject.Find("RetryButton").GetComponent<Button>();
        exit = GameObject.Find("BackButton").GetComponent<Button>();
        next1 = GameObject.Find("nextLevelButton1").GetComponent<Button>();
        next2= GameObject.Find("nextLevelButton2").GetComponent<Button>();
        lastScene = StaticData.lastScenario;

        reset.onClick.AddListener(restart);
        exit.onClick.AddListener(quit);

        if (lastScene.Equals("tutorialScene")) {
            next2.gameObject.SetActive(true);
            next1.onClick.AddListener(goodLevel);
            next1.GetComponentInChildren<Text>().text = "God's road";
            next2.onClick.AddListener(badLevel);
            next2.GetComponentInChildren<Text>().text = "Devil's road";
        }else
        {
            next2.gameObject.SetActive(false);
            next1.onClick.AddListener(nextLevel);
            next1.GetComponentInChildren<Text>().text = "Next level";
        }
    }
	

    //Cargar la escena siguiente dependiendo de si el mapa fue bueno o malo
    private void nextLevel() {
        AudioManager.StopAllAudio();
        if (lastScene.Equals("GodPath_1"))
        {
            SceneManager.LoadScene("GodPath_2");
        }
        else if (lastScene.Equals("SatanPath_1")) {
            SceneManager.LoadScene("SatanPath_2");
        }
    }

    private void goodLevel() {
        //Cargar escena de bueno
        SceneManager.LoadScene("GodPath_1");
        AudioManager.StopAllAudio();
    }

    private void badLevel() {
        //Cargar escena del malo
        SceneManager.LoadScene("SatanPath_1");
        AudioManager.StopAllAudio();
    }

    private void restart() {
        //Reinicia el ultimo nivel jugado
        SceneManager.LoadScene(lastScene);
        AudioManager.StopAllAudio();
    }

    private void quit() {
        //Sale al menu
        SceneManager.LoadScene("mainMenuScene");
        AudioManager.StopAllAudio();
    }
}
