using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerSceneMusic : MonoBehaviour {

    public string theme;

	// Use this for initialization
	void Start () {
        AudioManager.instance.Play(theme);
    }
	
}
