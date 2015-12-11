using UnityEngine;
using System.Collections;
using Utilities;

public class PowerUpTemplate : MonoBehaviour {

    public float timer = 10f;
    public string otherTag = "Player";
    public float rotationSpeed = 50f;
    private PowerUpSpawn manager;

    protected virtual void Awake() {
        if (manager == null) {
            manager = FindObjectOfType<PowerUpSpawn>();
        }
    }

	// Use this for initialization
	protected virtual void Start () {
	
	}
	
	// Update is called once per frame
	protected virtual void Update () {
        transform.Rotate(Vector3.up * rotationSpeed);
        if (gameObject.activeSelf)
            Invoke("DeactivateSelf", timer);
	}

    /// <summary>
    /// Overridable method by the children objects.
    /// </summary>
    /// <param name="other">Collider of another gameObject</param>
    protected virtual void OnTriggerEnter(Collider other) {
        
    }

    /// <summary>
    /// DeactivateSelf disables to current gameObject
    /// to an inactive state.
    /// </summary>
    protected void DeactivateSelf() {
        manager.subtactActiveCount();
        gameObject.SetActive(false);
    }
}
