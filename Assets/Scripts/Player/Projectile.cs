using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class Projectile : MonoBehaviour {

    // Amount of Damage a particle does
    public float damage = 20f;

    // Public reference to the particle
    public ParticleSystem damageParticles;
    private ParticleSystem particle;

    private void Awake() {

    }

    /// <summary>
    /// Collider detection, checks for the collider's parent object tag.
    /// </summary>
    /// <param name="other">"Other" references an outside collider that is hitting the current Object.</param>
    private void OnCollisionEnter(Collision other) {
		if (other.collider.CompareTag("Player")) {
			other.collider.GetComponent<Health>().TakeDamage(damage);
		}
        else if (other.collider.CompareTag("Obstacle")) {
            Destroy(gameObject);
        }
        Destroy(gameObject);
    }
   
}
