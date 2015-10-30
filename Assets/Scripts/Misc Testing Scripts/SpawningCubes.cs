using UnityEngine;
using System.Collections;

public class SpawningCubes : MonoBehaviour {
	
	public float teleportCooldown;
	public GameObject powerupRB;
	private MeshRenderer plane;
	
	public Vector3 center;
		
	public Vector3 radius;

	// Use this for initialization
	void Start () {
		plane = GetComponent<MeshRenderer>();
		Debug.Log(plane.bounds);
		
		center = plane.bounds.center;
		
		radius = plane.bounds.extents - new Vector3(1,0,1);
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Return))
		{
			Vector3 position = new Vector3(Random.Range(-radius.x, radius.x), 3, Random.Range(-radius.z, radius.z));
			Instantiate(powerupRB, position, new Quaternion(3,2,4,1));
		}
	}
}
