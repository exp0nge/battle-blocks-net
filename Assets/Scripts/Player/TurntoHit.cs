using UnityEngine;
using System.Collections;

/// <summary>
/// rotates particle system to look at projectile
/// </summary>
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
