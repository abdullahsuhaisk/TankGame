using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyTankAi : MonoBehaviour
{

    NavMeshAgent navMeshAi;
    Transform playerpos;
    Animator FsmAi;
    float distance;
    public Transform rayOrgin;
    float maxCheckDistance = 10f;
    int currentPoints;
    public Transform pa, pb;
    Vector3[] wayPoints; 

    void Start()
    {

        navMeshAi = GetComponent<NavMeshAgent>();
        playerpos = GameObject.FindGameObjectWithTag("Player").transform;
        //navMeshAi.SetDestination(playerpos.position);
        FsmAi = GetComponent<Animator>();
        currentPoints = 0;
        wayPoints=new Vector3[]{ pa.position, pb.position };
        navMeshAi.SetDestination(wayPoints[currentPoints]);

    }


    // Update is called once per frame
    void Update()
    {
        //Calculate Distance
        distance = Vector3.Distance(playerpos.position, transform.position);
        FsmAi.SetFloat("distance", distance);

        
        //navMeshAi.SetDestination(pa.position);



        //Visibility
        Vector3 dir = (playerpos.position - transform.position).normalized;
        RaycastHit hitinfo;
        Debug.DrawRay(rayOrgin.position, dir * maxCheckDistance, Color.yellow);

        if (Physics.Raycast(rayOrgin.position, dir, out hitinfo))
        {
            if (hitinfo.transform.tag == "Player")
            {
                Debug.Log("goruldu");
                FsmAi.SetBool("isVisible", true);
            }
            else
            {
                Debug.Log("gorulmedi");
                FsmAi.SetBool("isVisible", false);
            }
        }
        else
        {
            Debug.Log("gorulmedi");
            FsmAi.SetBool("isVisible", false);
        }
        //Calculate WayPoints distance GelipGelmediğene karar ver ve Mesafeyi FSm set et
        float wayPointsDistance = Vector3.Distance(wayPoints[currentPoints], transform.position);
        FsmAi.SetFloat("distanceFromWaypoint", wayPointsDistance);
    }
    public void SetNewPoint()
    {
        switch (currentPoints)
        {
            case 0:
                currentPoints = 1;
                break;
            case 1:
                currentPoints = 0;
                break;
        }
        navMeshAi.SetDestination(wayPoints[currentPoints]);
    }

    public void Shooting()
    {
        transform.GetComponent<TankShooting>().Shooting();

    }

    internal void Chosing()
    {
        navMeshAi.SetDestination(playerpos.position);
    }

    public void PatrolEnter()
    {
        navMeshAi.SetDestination(wayPoints[currentPoints]);
    }

    public void SetLookRatation()
    {
        Vector3 dir = playerpos.position - transform.position;
        dir=dir.normalized;

        Quaternion rot = new Quaternion();
        transform.rotation = Quaternion.Slerp(transform.rotation, rot, 0.1f); //CurrentRotation,TargetRotation,SpeedValue
   
    }
}
