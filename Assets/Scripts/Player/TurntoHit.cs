using UnityEngine;
using System.Collections;

public class TurntoHit : MonoBehaviour {
    
    public Transform projectile;
    
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.LookAt(projectile);	
	}
}
