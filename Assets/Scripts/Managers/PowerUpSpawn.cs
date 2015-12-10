using UnityEngine;
using System.Collections;

public class PowerUpSpawn : MonoBehaviour {

    // TODO: Rename the variable below, the names are terrible
    // I'm getting tired.
    public int amountSpawned = 2;
    public GameObject[] powerUps;
    private Transform[] spawnPoints;

    private void Awake() {
        spawnPoints = GetComponentsInChildren<Transform>();
    }

	// Use this for initialization
	void Start () {
	    for (int i = 0; i < powerUps.Length; i++) {
            for (int j = 0; j < amountSpawned; j++) {
                GameObject powerUp = Instantiate(powerUps[i], Vector3.zero, Quaternion.identity) as GameObject;
                powerUp.SetActive(false);
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
