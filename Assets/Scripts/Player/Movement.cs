using UnityEngine;
using System.Collections;

//Makes sure that the object has the right component
[RequireComponent(typeof(Rigidbody))]
public class Movement : MonoBehaviour {

    public string horizontalMovement = "Horizontal"; //used to set the string value for the correct player
    public string verticalMovement = "Vertical";
    public float playerSpeed = 5f;
    public float turnSpeed = 30f;

    private Rigidbody playerRigidbody;
    private float movementInput; //stores the input values from Input.GetAxis("Vertical")
    private float rotationInput; //Stores the input values from Input.GetAxis("Horizontal")
    public KeyCode dashInput = KeyCode.Return;
    public float dash = 1;

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
        if (Input.GetKeyDown(dashInput)){
            dash = 5;
            Vector3 movement;
            if (movementInput != 0){
                movement = transform.forward * dash * movementInput;
            }
            else {
                movement = transform.forward * dash * playerSpeed;
            }
            playerRigidbody.MovePosition(movement + playerRigidbody.position);
            dash = 1;
        }
        else{
            Vector3 movement = transform.forward * movementInput * playerSpeed * Time.deltaTime;
            playerRigidbody.MovePosition(movement + playerRigidbody.position);
        }
    }

    private void turn() {
        float turn = turnSpeed * rotationInput * Time.deltaTime * playerSpeed;
        Quaternion rotation = Quaternion.Euler(0f, turn, 0f);
        playerRigidbody.MoveRotation(playerRigidbody.rotation * rotation);
    }
}
