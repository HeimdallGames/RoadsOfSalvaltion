using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
public class acelerateFun : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{

	// Use this for initialization
	void Start () {
		
	}
    public void OnPointerDown(PointerEventData eventData)
    {
        StaticData.isAcel = true;
        Debug.Log("OnPointerDown");
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        StaticData.isAcel = false;
        Debug.Log("OnPointerUp");
    }
    // Update is called once per frame
    void Update () {
		
	}
}
