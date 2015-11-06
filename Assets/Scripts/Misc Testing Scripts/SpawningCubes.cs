using UnityEngine;
using System.Collections;

public class SpawningCubes : MonoBehaviour {
	
	public float teleportCooldown;
	public GameObject powerupRB;
	private MeshRenderer plane;
	
	public Vector3 center;
		
	public Vector3 radius;
	public float spawnCooldown;
	public float spawnRate;

	// Use this for initialization
	void Start () {
		spawnRate = 20;
		plane = GetComponent<MeshRenderer>();
		Debug.Log(plane.bounds);
		center = plane.bounds.center;
		radius = plane.bounds.extents - new Vector3(2,0,2);
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time > spawnCooldown)
		{
			spawnCooldown = Time.time + 20;
			for (int i = 0; i < 3; i++){
				Vector3 position = new Vector3(Random.Range(-radius.x, radius.x), 3, Random.Range(-radius.z, radius.z));
				Instantiate(powerupRB, position, Quaternion.identity);
			}
		}
	}
}
