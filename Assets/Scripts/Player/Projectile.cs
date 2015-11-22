using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class Projectile : MonoBehaviour {
    public ParticleSystem takeHit;
    public float damage = 20f; //Damage the projectile does.

    void Awake()
    {
      //  takehit = GetComponentInChildren<ParticleSystem>();
    }

    
    /// <summary>
    /// Collider detection, checks for the collider's parent object tag.
    /// </summary>
    /// <param name="other">"Other" references an outside collider that is hitting the current Object.</param>
    void OnTriggerEnter(Collider other) {
		if (other.CompareTag("Player")) {
			other.GetComponent<Health>().takeDamage(damage);
            Instantiate(takeHit, transform.position, Quaternion.Euler(1, 180, -90));// creates takeHit particles at impact
            Destroy(gameObject);
            
		}
        else if (other.CompareTag("Obstacle")) {
            Destroy(gameObject);
        }
    }
}
