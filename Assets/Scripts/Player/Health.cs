using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {

	public float health = 100f;

    /// <summary>
    /// Performs calculation on object health if health > 0
    /// </summary>
    /// <param name="damage"></param>
	public void takeDamage(float damage)
	{
		health -= damage;
		if(health <= 0)
			Destroy(gameObject);
	}
}
