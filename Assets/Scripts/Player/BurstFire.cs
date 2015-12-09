using UnityEngine;
using System.Collections;

public class BurstFire : ShooterTemplate {

	public float shotForce = 1000f;
	public float fireRate = 0.5f;
	public KeyCode shooterKey = KeyCode.Space;

	private float nextInterval;
	private int burstCount = 3;
	private float burstRate = 0.07f;					
	private int shotCount = 15;         //player can only fire 5 bursts (3*5 shots)

    protected override void Start() {
        base.Start();
    }

    protected override void Update () 
	{
		if (Input.GetButtonUp(fireButton) && Time.time > nextInterval && shotCount > 0) 
		{
			nextInterval = Time.time + fireRate;
			StartCoroutine(burst ());
		}
	}

    IEnumerator burst() {
        for (int i = 0; i < burstCount; i++) {
            Rigidbody shot = Instantiate(projectile, shotTransform.position, shotTransform.rotation) as Rigidbody;
            shot.AddForce(shotTransform.forward * shotForce);
            shotCount--;
            yield return new WaitForSeconds(burstRate);
        }
    }
}
