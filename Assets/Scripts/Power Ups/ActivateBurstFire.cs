using UnityEngine;
using System.Collections;

public class ActivateBurstFire : PowerUpTemplate {

    protected override void OnTriggerEnter(Collider other) {
        base.OnTriggerEnter(other);
        if (other.CompareTag(otherTag)) {
            other.GetComponent<BurstFire>().activateComponent();
            gameObject.SetActive(false);
        }
    }

    protected override void Update() {
        base.Update();
    }
}
