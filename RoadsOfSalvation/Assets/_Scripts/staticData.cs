﻿using UnityEngine;

public static class StaticData
{

    public static string lastScenario=""; //Cambio de int a string para almacenar los nombres y no los numeros (lioso)
    public static int punctuation=0;

    public static bool tutorialCompleted()
    {
        return PlayerPrefs.GetInt("tutorialCompleted", 1) == 1;
    }

    public static int goodLvl()
    {
        return PlayerPrefs.GetInt("currentGoodLvl", 1);
    }

    public static int badLvl()
    {
        return PlayerPrefs.GetInt("currentBadLvl", 1);
    }

    
}
