using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shell : MonoBehaviour
{
    private void Awake()
    {
        Destroy(gameObject, 3);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy" || other.gameObject.tag == "Player")
        {
           
            other.gameObject.GetComponent<TankHealth>().TakeDamege(10);
            Destroy(gameObject);
        }

        else
            Debug.Log("Collision other object");

    }
}
