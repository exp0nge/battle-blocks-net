using UnityEngine;
using System.Collections;

public class DestroyStuff_Test : MonoBehaviour {

    void OnTriggerEnter (Collider c)
    {
        if (c.CompareTag("Block"))
        {
            Destroy(c.gameObject);

        }
        Destroy(gameObject);
    }
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}
}
