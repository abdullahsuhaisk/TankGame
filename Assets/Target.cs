using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour {

    float yPos;
	void Start () {
        yPos = transform.position.y;
        
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Vector3 mousePos = Input.mousePosition;
            Ray ray = Camera.main.ScreenPointToRay(mousePos);
             Debug.DrawRay(ray.origin, ray.direction * 100, Color.black);

            RaycastHit hitInfo;

            if(Physics.Raycast(ray.origin,ray.direction,out hitInfo))
            {
                transform.position = new Vector3(hitInfo.point.x, yPos, hitInfo.point.z);
            }
        }
		
	}
}
