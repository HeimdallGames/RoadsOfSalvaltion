﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Meta : MonoBehaviour {

	// Use this for initialization
	void Start () {
        switch (SceneManager.GetActiveScene().name) { 
            case "tutorialScene":
                PlayerPrefs.SetInt("tutorialCompleted", 1);
            break;
            case "GodPath_2":
                if (PlayerPrefs.GetInt("currentGoodLvl", 0) < 2)
                    PlayerPrefs.SetInt("currentGoodLvl", 2);
                break;
            case "SatanPath_2":
                if (PlayerPrefs.GetInt("currentBadLvl", 0) < 2)
                    PlayerPrefs.SetInt("currentBadLvl", 2);
                break;
        }
    }
    
}
