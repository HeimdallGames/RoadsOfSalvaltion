using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class nextSceneFun : MonoBehaviour {
    private Button next1;
    private Button next2;

	void Start () {
        next1 = GameObject.Find("nextLevelButton1").GetComponent<Button>();
        next2= GameObject.Find("nextLevelButton2").GetComponent<Button>();
        if (StaticData.lastScenario.Equals("tutorialScene")) {
            next2.gameObject.SetActive(true);
            next1.GetComponentInChildren<Text>().text = "God's road";
            next2.GetComponentInChildren<Text>().text = "Devil's road";
        }else
        {
            next2.gameObject.SetActive(false);
            next1.GetComponentInChildren<Text>().text = "Next level";
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
