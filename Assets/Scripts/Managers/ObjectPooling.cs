using UnityEngine;
using System.Collections;

public class ObjectPooling : MonoBehaviour {

	void OnTriggerExit(Collider other) {
        if (other.CompareTag("Projectile")) {
            Destroy(other.gameObject);
        }
    }
}
