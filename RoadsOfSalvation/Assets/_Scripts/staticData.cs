using UnityEngine;

public static class StaticData
{

    public static int lastScenario=0;
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
