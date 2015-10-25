using UnityEngine;
using System.Collections;

public class healthbar : MonoBehaviour {
	
	public float health = 100f;
	
	public void damageTaken(float damage)
	{
		health -= damage;
	}
	
	void OnTriggerEnter(Collider c) {
		if(c.CompareTag("Block")) 
		{
			if (health > 0)
			{
				damageTaken(25f);
				Destroy(gameObject);
			}
			else if (health == 0)
			{
				Destroy(c.gameObject);
				Destroy(gameObject);
			}
		}
		Destroy(gameObject);
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
