using UnityEngine;
using System.Collections;

public class BurstFire : MonoBehaviour {

	public Rigidbody projectile;
	public Transform shotPosition;
	public float shotForce = 1000f;
	public float fireRate = 0.5f;
	public KeyCode shooterKey = KeyCode.Space;

	private float nextInterval;
	private int burstCount = 3;
	private float burstRate = 0.07f;					
	private int shotCount = 15;			//player can only fire 5 bursts (3*5 shots)

	IEnumerator burst()
	{
		for (int i = 0; i < burstCount; i++)
		{
			Rigidbody shot = Instantiate (projectile, shotPosition.position, shotPosition.rotation) as Rigidbody;
			shot.AddForce (shotPosition.forward * shotForce);
			shotCount--;
			yield return new WaitForSeconds (burstRate);
		}
	}
	

	void Update () 
	{
		if (Input.GetKey (shooterKey) && Time.time > nextInterval && shotCount > 0) 
		{
			nextInterval = Time.time + fireRate;
			StartCoroutine(burst ());
		}
	}
}