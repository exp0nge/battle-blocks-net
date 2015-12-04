using UnityEngine;
using System.Collections;

public enum PowerUpStates { isActive, isDeactive }

public class PolymorphismTest : MonoBehaviour {

    public float time = 5f;

    public virtual void StartTimer() {
        StartCoroutine("DestroyCube");
    }

    IEnumerator DestroyCube() {

        yield return new WaitForSeconds(time);
        gameObject.SetActive(false);
    }

    protected virtual void Start() {

    }

    protected virtual void Update() {
        if (Input.GetKeyUp(KeyCode.A))
        StartTimer();
    }


}
