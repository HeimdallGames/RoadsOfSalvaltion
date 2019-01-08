using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class brakeFun : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{

    // Use this for initialization
    void Start()
    {

    }
    public void OnPointerDown(PointerEventData eventData)
    {
        StaticData.isFren = true;
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        StaticData.isFren = false;
    }
    // Update is called once per frame
    void Update()
    {

    }
}