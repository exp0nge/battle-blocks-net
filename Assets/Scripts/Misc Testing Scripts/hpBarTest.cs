using UnityEngine;
using System.Collections;

public class hpBarTest : MonoBehaviour {
    public Health playerHealth;
    public KeyCode reduceHealth = KeyCode.A;
	// Use this for initialization
	void Start () {
	
	}

	// Update is called once per frame
	void Update () {
	if (Input.GetKeyDown(reduceHealth)) // reduces player health by 20 everytime A is pressed
        {
            playerHealth.takeDamage(20f);
        }
	}
}
