using UnityEngine;
using System.Collections;

public class healthbar : MonoBehaviour {
	
	public float health = 100f;
	
	void OnTriggerEnter(Collider c) {
		if(c.CompareTag("Block")) {
			health -= 25;
			if(health == 0){
				Destroy(c.gameObject);
			}
		}
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
