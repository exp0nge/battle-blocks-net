using UnityEngine;
using System.Collections;

//Makes sure that the object has the right component
[RequireComponent(typeof(Rigidbody))]
public class Movement : MonoBehaviour {

    //used to set the string value for the correct player
    public string horizontalMovement = "Horizontal";
    public string verticalMovement = "Vertical";
    public float playerSpeed = 5f;
    public float turnSpeed = 30f;

    private Rigidbody playerRigidbody;
    private float movementInput; //stores the input values from Input.GetAxis("Vertical")
    private float rotationInput; //Stores the input values from Input.GetAxis("Horizontal")
    public KeyCode teleportInput = KeyCode.Return;
    public float teleport = 1;
    private bool teleportCheck;
    public float teleportCooldown;

    void Awake() {
        playerRigidbody = GetComponent<Rigidbody>();
    }

	private void OnEnable() {
        //makes sure that physics does not affect the Rigidbody
        playerRigidbody.isKinematic = true;
        //reset the values of the inputs
        movementInput = 0f;
        rotationInput = 0f;
    }

	private void OnDisable() {
        //makes sure that physics does not affect the Rigidbody
        playerRigidbody.isKinematic = true;
    }

    //Update is called once every frame
    private void Update() {
        //Store the values of Input.GetAxis
        movementInput = Input.GetAxis(verticalMovement);
        rotationInput = Input.GetAxis(horizontalMovement);
        
    }

	//FixedUpdate() is used for physics calculation and runs every other frame
    private void FixedUpdate() {
        move();
        turn();
    }

    //using the Rigidbody to move the body
    private void move() {
        //Check if teleport key is pressed and teleport is off cooldown.
        if (Input.GetKeyDown(teleportInput) && Time.time > teleportCooldown && (transform.forward.y >= 0)){
            teleport = 5;
            teleportCooldown = Time.time + 3.0F;
            Vector3 movement;
            //If player is moving
            if (movementInput != 0){
                movement = transform.forward * teleport * movementInput;
            }
            //If player is still
            else {
                movement = transform.forward * teleport;
            }
            //Update position
            playerRigidbody.MovePosition(movement + playerRigidbody.position);
        }
        else{
            Vector3 movement = transform.forward * movementInput * playerSpeed * Time.deltaTime;
            playerRigidbody.MovePosition(movement + playerRigidbody.position);
        }
    }

    //using the rotationInput to scale how fast a player turns
    private void turn() {
        float turn = turnSpeed * rotationInput * Time.deltaTime * playerSpeed;
        Quaternion rotation = Quaternion.Euler(0f, turn, 0f);
        playerRigidbody.MoveRotation(playerRigidbody.rotation * rotation);
    }
    
    public void start(){
        
    }
}
