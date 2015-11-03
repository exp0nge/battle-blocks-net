using UnityEngine;
using System.Collections;

//[RequireComponent(typeof(Rigidbody))]
public class Projectile : MonoBehaviour {

    public float damage = 20f;

    void OnTriggerEnter(Collider other) {
		if (other.CompareTag("Player")) {
			other.GetComponent<Health>().damageTaken(damage);
			Destroy(gameObject);
		}
    }
}
