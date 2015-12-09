using UnityEngine;
using System.Collections;

public class ActivateShooter : MonoBehaviour {

    // TODO: Set Coroutine to control how long the gameObject lives.
    // TODO: Make have the power up handle it's life, this gameObject should just
    // call the lifetime function in each power up.
    // Use polymorphism.
    // Random spawning will have to be set using a preset locations instead of something completely random,
    // this will allow for various kinds of maps.

    public float timer = 30f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            other.GetComponent<LaunchProjectile>().enabled = !other.GetComponent<LaunchProjectile>().enabled;
            other.GetComponent<BurstFire>().enabled = !other.GetComponent<BurstFire>().enabled;
            StartCoroutine(resetComponents(other));
            gameObject.SetActive(false);
        }
    }

    /// <summary>
    /// Couroutine which toggles certain components on 
    /// the player prefab.
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    IEnumerator resetComponents(Collider other) {
        yield return new WaitForSeconds(timer);
        other.GetComponent<LaunchProjectile>().enabled = !other.GetComponent<LaunchProjectile>().enabled;
        other.GetComponent<BurstFire>().enabled = !other.GetComponent<BurstFire>().enabled;
        Debug.Log("Couroutine Ended");
    }
}
