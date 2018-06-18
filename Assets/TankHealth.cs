using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TankHealth : MonoBehaviour {

    public Text healthText;
    float health;

	void Awake () {
        health = 100;
        healthText.text = health.ToString();
	}
	
	public void TakeDamege(float amount)
    {
        health -= amount;
        if (health < 0)
        {
            health = 0;
            healthText.text = health.ToString();
            Destroy(gameObject);
        }
        healthText.text = health.ToString();
    }
}
