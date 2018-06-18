using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    Rigidbody rb;
    string movementAxis, turnAxis;
    float movementValue, turnValue;
    public float moveSpeed, turnSpeed;

    void Start()
    {

        rb = GetComponent<Rigidbody>();
        movementAxis = "Vertical";
        turnAxis = "Horizontal";

    }

    private void FixedUpdate()
    {

        movementValue = Input.GetAxis(movementAxis);
        turnValue = Input.GetAxis(turnAxis);

        Move();
        Turn();
    }

    private void Move()
    {
        //Kendi baktığı yöne doğru ilerleyecek
        Vector3 move = transform.forward * moveSpeed * movementValue * Time.deltaTime;
        rb.MovePosition(transform.position + move);  //Ötlemede toplanır
    }

    private void Turn()
    {
        float turn = turnValue * turnSpeed *Time.deltaTime;
        Quaternion rot = Quaternion.Euler(0, turn, 0);
        rb.MoveRotation(transform.rotation * rot);  //Dönme dönüşümlerinde çarpma yapılır
    }
}
