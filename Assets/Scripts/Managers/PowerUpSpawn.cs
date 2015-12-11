using UnityEngine;
using System.Collections.Generic;

public class PowerUpSpawn : MonoBehaviour {

    public int amountToSpawn = 2;
    public int amountActive = 0;
    public float powerupTimer = 5f;
    public GameObject[] powerUps;

    private Transform[] spawnPoints;
    private List<GameObject> allthePowerUps;
    private float timer;
    
    private void Awake() {
        timer = powerupTimer;
        spawnPoints = GetComponentsInChildren<Transform>();
        allthePowerUps = new List<GameObject>();
    }

	// Use this for initialization
	void Start () {
	    for (int i = 0; i < powerUps.Length; i++) {
            for (int j = 0; j < amountToSpawn; j++) {
                GameObject powerUp = Instantiate(powerUps[i], Vector3.zero, Quaternion.identity) as GameObject;
                allthePowerUps.Add(powerUp);
                powerUp.SetActive(false);
            }
        }
	}

    void randomPowerup()
    {
        int index = (int)Random.Range(0f, allthePowerUps.Count);
        allthePowerUps[index].transform.position = spawnPoints[(int)Random.Range(0f, (float)spawnPoints.Length)].position;
        allthePowerUps[index].SetActive(true);
        amountActive += 1;
    }
	
	// Update is called once per frame
	void Update () {
        timer -= Time.deltaTime;
        if (timer <= 0 && amountActive < 2)
        {
            randomPowerup();
            timer = powerupTimer;
        }
    }
}
