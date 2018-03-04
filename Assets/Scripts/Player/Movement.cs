using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

/// <summary>
/// Enums are a collection of states that can be enumerated
/// meaning that each state is assigned a number. 
/// This is generally used for locks and if you only want a
/// single thing to play.
/// </summary>
public enum MovementStates { isStill, isMoving, isDashing, isTeleporting };

//Makes sure that the object has the right component
[RequireComponent(typeof(Rigidbody))]
public class Movement : MonoBehaviour {

    public string horizontalMovement = "Horizontal";
    public string verticalMovement = "Vertical";
    public string dashInput = "Dash";
    public string teleportInput = "Teleport";
    //public KeyCode teleportInput = KeyCode.Return;
    //public KeyCode dashInput = KeyCode.LeftAlt;
    public float playerSpeed = 5f;
    public float turnSpeed = 30f;
    public float slideForce = 1000f; // Determines how strong the force should be applied to the rigidbody
    public float slideRate = 5f; // How often the player can slide
    private Rigidbody playerRigidbody;
    private float movementInput; // Stores the input values from Input.GetAxis("Vertical")
    private float rotationInput; // Stores the input values from Input.GetAxis("Horizontal")
    private float teleport = 1f;
    private float teleportCooldown;
    private float dashCooldown;


    // Create a reference to the enum states
    public MovementStates currentState;

    #region Unity Boot Methods
    void Awake() {
        playerRigidbody = GetComponent<Rigidbody>();
        //teleportfx = GetComponent<ParticleSystem>();
    }

	private void OnEnable() {
        //makes sure physics affects the rigidbody
        playerRigidbody.isKinematic = false;
        //reset the values of the inputs
        movementInput = 0f;
        rotationInput = 0f;
    }

	private void OnDisable() {
        //makes sure that physics does not affect the Rigidbody
        playerRigidbody.isKinematic = true;
    }

    // Update is called once every frame
    private void Update() {
        //Store the values of Input.GetAxis
        //movementInput = Input.GetAxis(verticalMovement);
        //rotationInput = Input.GetAxis(horizontalMovement);
        rotationInput = CrossPlatformInputManager.GetAxis(horizontalMovement);
        movementInput = CrossPlatformInputManager.GetAxis(verticalMovement);
    }

	// FixedUpdate() is used for physics calculation and runs every other frame
    private void FixedUpdate() {
        move();
        turn();
    }
    #endregion

    #region Movement Methods
    //using the Rigidbody to move the body
    private void move() {
        //Check if teleport key is pressed and teleport is off cooldown.
        if (Input.GetButtonDown(teleportInput) && Time.time > teleportCooldown && (transform.forward.y >= 0)) { 
            teleport = 5;
            teleportCooldown = Time.time + 3.0F;
            Vector3 movement;
            //If player is moving
            if (movementInput != 0) {
                movement = transform.forward * teleport * movementInput;
                // Sets the currentState to isTeleporting
                currentState = MovementStates.isTeleporting;
            }
            //If player is still
            else {
                movement = transform.forward * teleport;
                // Sets the currentState to isTeleporting
                currentState = MovementStates.isTeleporting;
            }
            // Update position with scale factor
            playerRigidbody.MovePosition(movement + playerRigidbody.position);
            // Debug.Log("Movement State: " + currentState);
        }
        else if (Input.GetButtonUp(dashInput) && Time.time > dashCooldown)
        {
            dashCooldown = Time.time + slideRate;
            dash();
            // Sets the currentState to isDashing
            currentState = MovementStates.isDashing;
            // Debug.Log("Movement State: " + currentState);
        }
        else if ( movementInput != 0) {
            Vector3 movement = transform.forward * movementInput * playerSpeed * Time.deltaTime;
            playerRigidbody.MovePosition(movement + playerRigidbody.position);
            // Sets the currentState to isMoving
            currentState = MovementStates.isMoving;
            // Debug.Log("Movement State: " + currentState);
        }
        else {
            currentState = MovementStates.isStill;
            // Debug.Log("Movement State: " + currentState);
        }
        
    }

    //using the rotationInput to scale how fast a player turns
    private void turn() {
        float turn = turnSpeed * rotationInput * Time.deltaTime * playerSpeed;
        Quaternion rotation = Quaternion.Euler(0f, turn, 0f);
        playerRigidbody.MoveRotation(playerRigidbody.rotation * rotation);
    }

    private void dash() {
        GetComponentInParent<Rigidbody>().AddForce(gameObject.transform.forward * slideForce);
    }
    #endregion

    #region Getters
    /// <summary>
    /// Use this method to grab the currentState
    /// of the Player's movement
    /// </summary>
    /// <returns>Returns a MovementState</returns>
    public MovementStates getMovementState() {
        return currentState;
    }
    #endregion

}
