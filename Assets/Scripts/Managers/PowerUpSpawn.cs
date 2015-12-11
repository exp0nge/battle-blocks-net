using UnityEngine;
using System.Collections.Generic;
using Utilities.Singleton;

public class PowerUpSpawn : Singleton<PowerUpSpawn> {

    public int amountToSpawn = 2;
    public int amountActive = 0;
    public float powerupTimer = 5f;

    [Range(0f, 1f)]
    public float spawnChance = 0.5f;
    public GameObject[] powerUps;

    private Transform[] spawnPoints;
    private List<GameObject> allthePowerUps;
    private float timer;

    protected override void OnAwake() {
        base.OnAwake();
        timer = powerupTimer;
        spawnPoints = GetComponentsInChildren<Transform>();
        allthePowerUps = new List<GameObject>();
    }

	// Use this for initialization
	private void Start () {
	    for (int i = 0; i < powerUps.Length; i++) {
            for (int j = 0; j < amountToSpawn; j++) {
                GameObject powerUp = Instantiate(powerUps[i], Vector3.zero, Quaternion.identity) as GameObject;
                allthePowerUps.Add(powerUp);
                powerUp.SetActive(false);
            }
        }
	}

    // Update is called once per frame
    private void Update() {
        timer -= Time.deltaTime;
        if (Random.value < spawnChance) {
            if (timer <= 0 && amountActive < 2) {
                randomPowerup();
                timer = powerupTimer;
            }
        }
    }

    /// <summary>
    /// Decrements the public field amountActive.
    /// </summary>
    public void subtactActiveCount() {
        if (amountActive > 0)
            amountActive -= 1;
    }


    /// <summary>
    /// Gets a random Power Up GameObject Prefab and enables it
    /// to a set position.
    /// </summary>
    private void randomPowerup() {
        int index = (int)Random.Range(0f, allthePowerUps.Count);
        allthePowerUps[index].transform.position = spawnPoints[(int)Random.Range(0f, spawnPoints.Length)].position;
        allthePowerUps[index].SetActive(true);
        amountActive += 1;
    }
}
