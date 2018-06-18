using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Touch : Sense {
    Aspect aspect;
    public override void Initialize()
    {
        
    }

    public override void UpdateSense()
    {
        if (aspect != null)
        {
            if (aspect.tankAspect == taspect)
                Debug.Log("Has been touched");
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        aspect = other.GetComponent<Aspect>();
    }
    private void OnTriggerExit(Collider other)
    {
        aspect = null;
    }
}
