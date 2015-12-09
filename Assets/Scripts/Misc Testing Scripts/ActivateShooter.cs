using UnityEngine;
using System.Collections;

public class ActivateShooter : MonoBehaviour {

    // TODO: Set Coroutine to control how long the gameObject lives.
    // Use polymorphism.
    // Random spawning will have to be set using a preset locations instead of something completely random,
    // this will allow for various kinds of maps.

    public GameObject player;
    public float timer = 10f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            player.GetComponent<LaunchProjectile>().enabled = !player.GetComponent<LaunchProjectile>().enabled;
            player.GetComponent<BurstFire>().enabled = !player.GetComponent<BurstFire>().enabled;
            StartCoroutine(resetComponents());
        }
    }

    IEnumerator resetComponents() {
        yield return new WaitForSeconds(timer);
        player.GetComponent<LaunchProjectile>().enabled = !player.GetComponent<LaunchProjectile>().enabled;
        player.GetComponent<BurstFire>().enabled = !player.GetComponent<BurstFire>().enabled;
        Debug.Log("Couroutine Ended");
    }
}
