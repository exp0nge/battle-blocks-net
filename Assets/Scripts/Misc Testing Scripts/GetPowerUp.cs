using UnityEngine;
using System.Collections;

public class GetPowerUp : MonoBehaviour {
	
	private int state;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	}
	
	void OnCollisionEnter (Collision col){
		if (col.gameObject.name == "Powerup(Clone)"){
			Destroy(col.gameObject);
			state = Random.Range(0, 1);
			// TODO: Do case switch apply powerup
		}
	}
}
