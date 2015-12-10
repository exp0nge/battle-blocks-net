using UnityEngine;

public class CameraControl : MonoBehaviour {
    public float dampTime = 0.2f;                 // Approximate time for the camera to refocus.
    public float screenEdgeBuffer = 4f;           // Space between the top/bottom most target and the screen edge.
    public float minSize = 6.5f;                  // The smallest orthographic size the camera can be.

    public Transform[] playerTargets;             // All the targets the camera needs to encompass.

    private Camera camera;                        // Used for referencing the camera.
    private float zoomSpeed;                      // Reference speed for the smooth damping of the orthographic size.
    private Vector3 moveVelocity;                 // Reference velocity for the smooth damping of the position.
    private Vector3 desiredPosition;              // The position the camera is moving towards.


    private void Awake() {
        camera = GetComponentInChildren<Camera>();
    }
    
    private void FixedUpdate() {
        // Move the camera towards a desired position.
        Move();

        // Change the size of the camera based.
        ZoomCamera();
    }
    
    private void Move() {
        // Find the average position of the targets.
        GetAvgPosition();

        // Smoothly transition to that position.
        transform.position = Vector3.SmoothDamp(transform.position, desiredPosition, ref moveVelocity, dampTime);
    }

    private void GetAvgPosition() {
        Vector3 averagePos = new Vector3();
        int numberOfTargets = 0;

        // Go through all the targets and add their positions together.
        for (int i = 0; i < playerTargets.Length; i++) {
            // If the target isn't active, go on to the next one.
            if (playerTargets[i].gameObject.activeSelf) {
                // Add to the average and increment the number of targets in the average.
                averagePos += playerTargets[i].position;
                numberOfTargets++;
            }
        }

        // If there are targets divide the sum of the positions by the number of them to find the average.
        if (numberOfTargets > 0)
            averagePos /= numberOfTargets;

        // Keep the same y value.
        averagePos.y = transform.position.y;

        // The desired position is the average position;
        desiredPosition = averagePos;
    }
    
    private void ZoomCamera() {
        // Find the required size based on the desired position and smoothly transition to that size.
        float requiredSize = GetSize();
        camera.orthographicSize = Mathf.SmoothDamp(camera.orthographicSize, requiredSize, ref zoomSpeed, dampTime);
    }
    
    private float GetSize() {
        // Find the position the camera rig is moving towards in its local space.
        Vector3 desiredLocalPos = transform.InverseTransformPoint(desiredPosition);

        // Start the camera's size calculation at zero.
        float size = 0f;

        for (int i = 0; i < playerTargets.Length; i++) {
            // Check if the player is active in the Hierarchy
            if (playerTargets[i].gameObject.activeSelf) {
                // Get the position of the target in the camera's local space
                Vector3 targetLocalPos = transform.InverseTransformPoint(playerTargets[i].position);

                // Get the position of the target from the desired position of the camera's local space
                Vector3 desiredPosToTarget = targetLocalPos - desiredLocalPos;

                // Choose the largest out of the current size and the distance of the tank 'up' or 'down' from the camera
                size = Mathf.Max(size, Mathf.Abs(desiredPosToTarget.y));

                // Choose the largest out of the current size and the calculated size based on the tank 
                // being to the left or right of the camera
                size = Mathf.Max(size, Mathf.Abs(desiredPosToTarget.x) / camera.aspect);
            }
        }

        // Adds the edge's screen buffer
        size += screenEdgeBuffer;

        // Checks the camera's size
        size = Mathf.Max(size, minSize);

        return size;
    }
    
    public void SetStartAndPosition() {
        GetAvgPosition();

        // Set the camera's position to the desired position without damping.
        transform.position = desiredPosition;

        // Find and set the required size of the camera.
        camera.orthographicSize = GetSize();
    }
}
