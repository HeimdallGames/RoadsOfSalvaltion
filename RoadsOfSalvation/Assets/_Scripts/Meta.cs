using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Meta : MonoBehaviour {


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player") { 
            switch (SceneManager.GetActiveScene().name)
            {
                case "tutorialScene":
                    PlayerPrefs.SetInt("tutorialCompleted", 0);
                    break;
                case "GodPath_1":
                    if (PlayerPrefs.GetInt("currentGoodLvl", 0) < 2)
                        PlayerPrefs.SetInt("currentGoodLvl", 2);
                    break;
                case "SatanPath_1":
                    if (PlayerPrefs.GetInt("currentBadLvl", 0) < 2)
                        PlayerPrefs.SetInt("currentBadLvl", 2);
                    break;
            }
        }
    }

}
