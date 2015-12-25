using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour {

    public float baseHealth = 100f;
    public ParticleSystem deathEffect;
    public Image healthHUD;

    // Reference to the public field, baseHealth
    private float currentHealth;
    // Reference to the GameManager
    private GameManager manager;

    private void Awake() {
        currentHealth = baseHealth;
        manager = (GameManager)FindObjectOfType(typeof(GameManager));
    }

    private void Start() {
    }            

    /// <summary>
    /// Calculates the baseHealth of the current player. If currentHealth
    /// falls below 0, then the object is destroyed. Additionally sets the
    /// baseHealth bar to an appropriate color depending on the baseHealth.
    /// </summary>
    /// <param name="damage">Float,value to be subtracted from currentHealth</param>
    public void TakeDamage(float damage)
	{
		currentHealth -= damage;
        if (currentHealth <= 0) {
            Instantiate(deathEffect, transform.position, Quaternion.Euler(270, 0, 0)); // instantiates and plays Explode 
            gameObject.SetActive(false);
            manager.ShowEndScreen(GetComponent<LaunchProjectile>().playerNumber);
        }
        healthHUD.fillAmount = SetFillAmount();
        SetHealthColor();
    }

    /// <summary>
    /// Adds a set value to the currentHealth, if the currentHealth
    /// is greater than or equal to the baseHealth, the currentHealth
    /// is set to be equal to the baseHealth.
    /// </summary>
    /// <param name="amount">Float, value to be added to currentHealth</param>
    public void HealHealth(float amount) {
        currentHealth += amount;
        if (currentHealth >= baseHealth) {
            currentHealth = baseHealth;
        }
        healthHUD.fillAmount = SetFillAmount();
        SetHealthColor();
    }

    /// <summary>
    /// Checks the current baseHealth and sets an appropriate color 
    /// value to the Image component.
    /// </summary>
    private void SetHealthColor() {
        if (currentHealth <= 66 && currentHealth > 33)
            healthHUD.color = Color.yellow;
        else if (currentHealth <= 33 && currentHealth > 0)
            healthHUD.color = Color.red;
    }

    /// <summary>
    /// Sets the fillAmount of an Image to be the ratio
    /// of currentHealth and the baseHealth;
    /// </summary>
    /// <returns>Float value between 0 and 1 that sets the health's value</returns>
    private float SetFillAmount() {
        return currentHealth / baseHealth;
    }
}
