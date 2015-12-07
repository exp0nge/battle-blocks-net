using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class Projectile : MonoBehaviour {

    public float damage = 20f; //Damage the projectile does.

    private ParticleSystem damageParticles;

    private void Awake() {
        // damageParticles = GetComponentInChildren<ParticleSystem>();
        // Debug.Log(damageParticles.name);
    }

    /// <summary>
    /// Collider detection, checks for the collider's parent object tag.
    /// </summary>
    /// <param name="other">"Other" references an outside collider that is hitting the current Object.</param>
    private void OnTriggerEnter(Collider other) {
		if (other.CompareTag("Player")) {
			other.GetComponent<Health>().takeDamage(damage);
		}
        else if (other.CompareTag("Obstacle")) {
            Destroy(gameObject);
        }
    }
   
}
