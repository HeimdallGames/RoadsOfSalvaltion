using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private float acel = 1000.0f;
    private float velBase;
    private float velMax;
    

    private Rigidbody rb;

    Vector3 movement;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        if (moveHorizontal > velMax) moveHorizontal = velMax;

        movement = new Vector3(moveHorizontal+ velBase, 0.0f, 0.0f);

        rb.AddForce(movement * acel);
    }
}

