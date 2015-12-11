using UnityEngine;
using System.Collections;

public class PowerUpTemplate : MonoBehaviour {

    public float timer = 10f;
    public string otherTag = "Player";

	// Use this for initialization
	protected virtual void Start () {
	
	}
	
	// Update is called once per frame
	protected virtual void Update () {
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
        gameObject.SetActive(false);
    }
}
