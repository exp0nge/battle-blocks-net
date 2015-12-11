using UnityEngine;
using System.Collections;

public class PowerUpTemplate : MonoBehaviour {

    public float timer = 10f;
    public string otherTag = "Player";


    protected virtual void OnEnabled() {
        Debug.Log("Called");
        StartCoroutine(StartObjectLifeTime());
    }

	// Use this for initialization
	protected virtual void Start () {
	
	}
	
	// Update is called once per frame
	protected virtual void Update () {
	
	}

    protected virtual void OnTriggerEnter(Collider other) {
        
    }

    protected virtual IEnumerator StartObjectLifeTime() {
        yield return new WaitForSeconds(timer);
        gameObject.SetActive(false);
        Debug.Log(gameObject.name + " is deactivated");
    }
}
