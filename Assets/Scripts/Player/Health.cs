using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {
    public ParticleSystem deathEffect;
    //public ParticleSystem takeHitEffect;
    //private Vector3 particleLocation;
    //public Transform projectile;
	public float health = 100f;
    //public ParticleSystem takeHit;

    /// <summary>
    /// Performs calculation on object health if health > 0
    /// </summary>
    /// <param name="damage"></param>
    ///
    void Awake() {
        //particle = GetComponentsInChildren<ParticleSystem>();
    }


    public void takeDamage(float damage)
	{
		health -= damage;

        if (health <= 0)
        {
            Instantiate(deathEffect, transform.position , Quaternion.Euler(270,0,0)); // instantiates and plays Explode 
            Destroy(gameObject);
            Destroy(deathEffect);
        }
	}
}
