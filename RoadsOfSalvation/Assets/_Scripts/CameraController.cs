using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{

    public GameObject player;

    private Vector3 offset=new Vector3(2,0,0);
    void Start()
    {
        offset = transform.position - player.transform.position;
    }

    void LateUpdate()
    {
       transform.position = player.transform.position + offset;
    }
}

