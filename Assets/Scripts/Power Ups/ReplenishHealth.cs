using UnityEngine;
using System.Collections;

public class ReplenishHealth : PowerUpTemplate {

    public float replenishValue = 20f;

    protected override void OnEnabled() {
        base.OnEnabled();
    }

    protected override void OnTriggerEnter(Collider other) {
        base.OnTriggerEnter(other);
        if (other.CompareTag(otherTag)) {
            other.GetComponent<Health>().HealHealth(replenishValue);
            gameObject.SetActive(false);
        }
    }

    protected override void Update() {
        base.Update();
        if (!isActive) {
            Debug.Log("Deactivating " + gameObject.name);
            Invoke("DeactivateSelf", timer);
            isActive = true;
        }
    }
}
