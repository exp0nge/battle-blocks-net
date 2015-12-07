using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour {

    public float health = 100f;
    public ParticleSystem deathEffect;
    public Image healthHUD;

    // Reference to the public field, health
    private float currentHealth;

    private void Awake() {
        currentHealth = health;
    }

    /// <summary>
    /// Calculates the health of the current player. If currentHealth
    /// falls below 0, then the object is destroyed. Additionally sets the
    /// health bar to an appropriate color depending on the health.
    /// </summary>
    /// <param name="damage">Float value, amount to subtract</param>
    public void takeDamage(float damage)
	{
		currentHealth -= damage;
        healthHUD.fillAmount = currentHealth / 100f;

        if (currentHealth <= 0) {
            Instantiate(deathEffect, transform.position, Quaternion.Euler(270, 0, 0)); // instantiates and plays Explode 
            gameObject.SetActive(false);
        }
        else if (currentHealth <= 66 && currentHealth > 33)
            healthHUD.color = Color.yellow;
        else if (currentHealth <= 33 && currentHealth > 0)
            healthHUD.color = Color.red;
    }
}
