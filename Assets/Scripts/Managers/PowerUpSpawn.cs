using UnityEngine;
using System.Collections.Generic;

public class PowerUpSpawn : MonoBehaviour {

    // TODO: Rename the variable below, the names are terrible
    // I'm getting tired.
    public int amountToSpawn = 2;
    public int amountActive = 0;
    public float powerupTimer = 5f;
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
            for (int j = 0; j < amountToSpawn; j++) {
                GameObject powerUp = Instantiate(powerUps[i], Vector3.zero, Quaternion.identity) as GameObject;
                allthePowerUps.Add(powerUp);
                powerUp.SetActive(false);
            }
        }
	}
    void randomPowerup()
    {
        int index = (int)Random.Range(0f, (float)allthePowerUps.Count);
        allthePowerUps[index].transform.position = spawnPoints[(int)Random.Range(0f, (float)spawnPoints.Length)].position;
        allthePowerUps[index].SetActive(true);
        Debug.Log(allthePowerUps[index].name);
        amountActive += 1;
    }
	
	// Update is called once per frame
	void Update () {
        powerupTimer -= Time.deltaTime;
        //for (int i = 0; i < allthePowerUps.Count; i++)
        //{
        //    if (allthePowerUps[i].activeInHierarchy)
        //        amountActive += 1;
        //}
        if (powerupTimer <= 0 && amountActive < 2)
        {
            randomPowerup();
            powerupTimer = 3f;

        }
    }
}
