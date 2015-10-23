using UnityEngine;
using System.Collections;

//Makes sure that the object has the right component
[RequireComponent(typeof(Rigidbody))]
public class Movement : MonoBehaviour {

    public string horizontalMovement = "Horizontal"; //used to set the string value for the correct player
    public string verticalMovement = "Vertical";
    public float playerSpeed = 1f;
    public float turnSpeed = 1f;

    private Rigidbody playerRigidbody;
    private float movementInput; //stores the input values from Input.GetAxis("Vertical")
    private float rotationInput; //Stores the input values from Input.GetAxis("Horizontal")
    

    void Awake() {
        playerRigidbody = GetComponent<Rigidbody>();
    }

	private void OnEnable() {
        //makes sure that on start the kinematic component is turned off
        playerRigidbody.isKinematic = false;
        //reset the values of the inputs
        movementInput = 0f;
        rotationInput = 0f;
    }

	private void OnDisable() {
        //return the kinematic component to on
        playerRigidbody.isKinematic = true;
    }

    private void Update() {
        movementInput = Input.GetAxis(verticalMovement);
        rotationInput = Input.GetAxis(horizontalMovement);
    }

	//FixedUpdate() is used for physics calculation and runs every other frame
    private void FixedUpdate() {
        move();
        turn();
    }

    private void move() {
        Vector3 movement = transform.forward * movementInput * playerSpeed * Time.deltaTime;
        playerRigidbody.MovePosition(movement + playerRigidbody.position);
    }

    private void turn() {
        float turn = turnSpeed * rotationInput * Time.deltaTime;
        Quaternion rotation = Quaternion.Euler(0f, turn, 0f);
        playerRigidbody.MoveRotation(playerRigidbody.rotation * rotation);
    }
}
