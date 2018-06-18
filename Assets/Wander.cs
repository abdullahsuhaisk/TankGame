
using System;
using UnityEngine;

public class Wander : MonoBehaviour
{
    public Animator anim;
    Vector3 target;
    float rotspeed = 5f;
    float movespeed = 5f;
    float xMin, xMax, zMin, zMax;
    float yPos;
    public float value;
    void Start()
    {
        Initialize();

    }

    private void Initialize()
    {
        xMin = -value;
        xMax = value;
        zMin = -value;
        zMax = value;
        yPos = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        CurrentDistance();
        //if (Vector3.Distance(target, transform.position) < 2f)
           // SetNewTarget(); //Animden Çağır
        //Vector3.Distance(a,b) float değer döner
        //else
        //{
        //    MoveTarget(); //Animden çağır
        //}

    }

    private void CurrentDistance()
    {
        var distance = Vector3.Distance(target, transform.position);
        anim.SetFloat("distance", distance);

    }

    public void SetNewTarget()
    {
        
        var xPos = UnityEngine.Random.Range(xMin, xMax + 3);
        var zPos = UnityEngine.Random.Range(zMin, zMax );

        target =new Vector3 (xPos, yPos, zPos);
    }

    public void MoveTarget()
    {
        var dir = (target - transform.position).normalized;
        Quaternion rotation = new Quaternion();
        rotation.SetLookRotation(dir);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotspeed * Time.deltaTime);
        transform.Translate(Vector3.forward * movespeed * Time.deltaTime);
    }
}
