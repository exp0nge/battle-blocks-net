using UnityEngine;
using System.Collections;

public class ObjectPooling : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

	void OnTriggerExit(Collider other) {
		if (other.CompareTag("Projectile"))
            Debug.Log("Projectile");
    }
}
