using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Sense : MonoBehaviour,ISenseBehavior {
    public abstract void Initialize();
    public abstract void UpdateSense();
    protected float eleapsedTime;
    protected float detectedtime;
    protected TankAspect taspect = TankAspect.ENEMY;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        eleapsedTime = Time.time;
        //Belirli aralıklar ile güncelleme yapması Optimizasyon
        if (eleapsedTime > detectedtime)
        {
            UpdateSense();
            detectedtime = eleapsedTime + 0.2f;
        }
	}
}
