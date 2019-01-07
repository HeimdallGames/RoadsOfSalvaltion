using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoadSceneOnClick : MonoBehaviour
{

    public void LoadScene(string sceneName)
    {
        AudioManager.StopAllAudio();
        SceneManager.LoadScene(sceneName);
    }
}