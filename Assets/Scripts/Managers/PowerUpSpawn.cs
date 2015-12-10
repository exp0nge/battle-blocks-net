using UnityEngine;
using System.Collections.Generic;

public class PowerUpSpawn : MonoBehaviour {

    // TODO: Rename the variable below, the names are terrible
    // I'm getting tired.
    public int amountSpawned = 2;
    public float powerupTimer = 3f;
    public GameObject[] powerUps;
    private Transform[] spawnPoints;
    private List<GameObject> allthePowerUps;
    
    private void Awake() {
        spawnPoints = GetComponentsInChildren<Transform>();
        allthePowerUps = new List<GameObject>();
    }

	// Use this for initialization
	void Start () {
	    for (int i = 0; i < powerUps.Length; i++) {
            for (int j = 0; j < amountSpawned; j++) {
                GameObject powerUp = Instantiate(powerUps[i], Vector3.zero, Quaternion.identity) as GameObject;
                allthePowerUps.Add(powerUp);
                powerUp.SetActive(false);
            }
        }
	}
    void randomPowerup()
    {
        int index = (int)Random.Range(0f, (float)allthePowerUps.Count);
        allthePowerUps[index].SetActive(true);
        Debug.Log(allthePowerUps[index].name);
        allthePowerUps[index].transform.position = spawnPoints[(int)Random.Range(0f,(float)spawnPoints.Length)].position;
    }
	
	// Update is called once per frame
	void Update () {
        powerupTimer -= Time.deltaTime;
        if (powerupTimer <= 0)
        {
            for(int i = 0; i < allthePowerUps.Count; i++)
            {
                if (allthePowerUps[i].activeInHierarchy)
                    powerupTimer = 3f; 
            }
            randomPowerup();
            powerupTimer = 3f;
        }

	
	}
}
