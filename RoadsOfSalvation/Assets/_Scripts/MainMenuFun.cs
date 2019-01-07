using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuFun : MonoBehaviour {

    public Button startButton;
    public GameObject choosePathMenu, mainMenu;
    public GameObject buttonsGood, buttonsEvil;

    // Use this for initialization
    void Start () {
        AudioManager.instance.Play("MenuTheme");
        if (StaticData.tutorialCompleted())
        {
            startButton.onClick.AddListener(delegate {
                AudioManager.StopAllAudio();
                SceneManager.LoadScene("tutorialScene"); });
        }
        else
        {
            startButton.onClick.AddListener(delegate { goToChoosePath(); });
        }

        for(int i = 0; i < StaticData.goodLvl(); i++)
        {
            buttonsGood.transform.GetChild(i).gameObject.SetActive(true);
        }
        for (int i = 0; i < StaticData.badLvl(); i++)
        {
            buttonsEvil.transform.GetChild(i).gameObject.SetActive(true);
        }
    }

	
	private void goToChoosePath()
    {
        mainMenu.SetActive(false);
        choosePathMenu.SetActive(true);
    }
}
