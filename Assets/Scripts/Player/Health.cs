using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {
    public ParticleSystem deathEffect;
    public ParticleSystem hitEffect;

	public float health = 100f;

    /// <summary>
    /// Performs calculation on object health if health > 0
    /// </summary>
    /// <param name="damage"></param>
    ///
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
