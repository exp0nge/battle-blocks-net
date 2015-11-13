 using UnityEngine;
using System.Collections;

public class Shooter : MonoBehaviour {

	public Rigidbody projectile;
	public Transform shotPosition;
	public float shotForce = 1000f;
	public float fireRate = 0.5f;
    public KeyCode shooterKey = KeyCode.Space;

    private float nextInterval;

	// Update is called once per frame
	void Update () {
		//Player will shoot if input is true and if the time interval is greater than the set interval
		if (Input.GetKey (shooterKey) && Time.time > nextInterval) 
		{
			nextInterval = Time.time + fireRate;
			Rigidbody shot= Instantiate (projectile, shotPosition.position, shotPosition.rotation) as Rigidbody;
			shot.AddForce (shotPosition.forward * shotForce);
		}
	}
}
