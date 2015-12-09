using UnityEngine;
using System.Collections;

public class ShooterTemplate : MonoBehaviour {

    public int playerNumber = 1;
    public Rigidbody projectile;
    public Transform shotTransform;

    protected string fireButton;

	// Use this for initialization
	protected virtual void Start () {
        fireButton = "Fire" + playerNumber;
    }

    // Update is called once per frame
    protected virtual void Update () {
	
	}
}
