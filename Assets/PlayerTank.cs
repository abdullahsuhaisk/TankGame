using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTank : MonoBehaviour
{

    Transform target;
    float turnSpeed = 250f;
    float moveSpeed = 15f;
    string movementAxis, turnAxis;
    float movementValue, turnValue;
    public Rigidbody rb;
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Target").transform;
        rb = GetComponent<Rigidbody>();
        movementAxis = "Vertical";
        turnAxis = "Horizontal";

    }

    // Update is called once per frame
    void Update()
    {
       // if (Vector3.Distance(target.position, transform.position) < 2f) return;
        //Vector3.Distance(a,b) float değer döner
       // else
        //{
            //MoveTarget();
        //}
        Move();
        Turn();
        movementValue = Input.GetAxis(movementAxis);
        turnValue = Input.GetAxis(turnAxis);

    }

    private void MoveTarget()
    {
        //var dir = (target.position - transform.position).normalized;
        //Quaternion rotation = new Quaternion();
        //rotation.SetLookRotation(dir);
        //transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotspeed * Time.deltaTime);
        //transform.Translate(Vector3.forward * movespeed * Time.deltaTime);
        

    }
    private void Move()
    {
        //Kendi baktığı yöne doğru ilerleyecek
        Vector3 move = transform.forward * moveSpeed * movementValue * Time.deltaTime;
        rb.MovePosition(transform.position + move);  //Ötlemede toplanır
    }

    private void Turn()
    {
        float turn = turnValue * turnSpeed * Time.deltaTime;
        Quaternion rot = Quaternion.Euler(0, turn, 0);
        rb.MoveRotation(transform.rotation * rot);  //Dönme dönüşümlerinde çarpma yapılır
    }
}
