using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class gameOverFun : MonoBehaviour {

    public Text Score_UIText, newRecordMessage;
    public InputField playerName;
    public Button retry;

    void Start()
    {
        Score_UIText.text = StaticData.punctuation+""; //El truco del almendruco

        retry.onClick.AddListener(delegate { playAgain(); });

    }

    void playAgain()
    {
        SceneManager.LoadScene(StaticData.lastScenario);
        AudioManager.StopAllAudio();
    }

    
}
