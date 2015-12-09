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
    private void OnTriggerEnter(Collider other) {
		if (other.CompareTag("Player")) {
			other.GetComponent<Health>().takeDamage(damage);
		}
        else if (other.CompareTag("Obstacle")) {
            Destroy(gameObject);
        }
        particle = Instantiate(damageParticles, transform.position, Quaternion.Euler(0, 180, 0)) as ParticleSystem;
        particle.Play();
        Destroy(gameObject);
    }
   
}
