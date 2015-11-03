using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {

	public float health = 100f;

	public void damageTaken(float damage)
	{
		health -= damage;
		if(health <= 0)
			Destroy(gameObject);
	}
	/*
	void OnTriggerEnter(Collider c) {//c is whatever is hitting the gameObject the script is attatched to
		//Debug.Log(c.gameObject);
		if(c.CompareTag("Projectile"))
		{
			damageTaken(33f);
			Destroy(c.gameObject);
		}
		//Debug.Log(health);
	}
	*/
}
