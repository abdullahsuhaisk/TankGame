using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankShooting : MonoBehaviour {


    public GameObject shellPrefab;
    public float moveSpeed = 500f;
    public Transform sheelSpawn;
    public bool isAI=false;

    private void FixedUpdate()
    {
        if (isAI)
            return;

        if (Input.GetKey(KeyCode.Space))
        {
            Shooting();
        }        
    }
    float TimePassed = 1f;
    float frequency = 5f;

    public void Shooting()
    {
        if (Time.time > TimePassed) //Time.time geçen Toplam Süre !Time.deltaTime zaman frame değişimi
        {
            GameObject shell = Instantiate(shellPrefab, sheelSpawn.position, Quaternion.identity);
            shell.GetComponent<Rigidbody>().velocity = transform.forward * moveSpeed * Time.deltaTime;
            TimePassed = Time.time+1/frequency;
            
        }
   
    }
}
