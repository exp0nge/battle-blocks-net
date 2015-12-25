using UnityEngine;
using System.Collections;

public class HUD_Screen : UI_Screen {
    //public Rigidbody playerRigidBody;
    public float health;
    public Health playerHealth;
    public string hpBar = "HP Bar";
    // Use this for initialization
    protected override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {
        
            //baseHealth = (playerRigidBody.GetComponent<Health>().baseHealth) / 100;
            health = playerHealth.baseHealth / 100f;
            //fillHealth = baseHealth / 100;
            //SetImageFill(hpBar, baseHealth);
            if (health >= .7f)
            {
                SetImageFill(hpBar, health);
                SetImageColor(hpBar, Color.green);
            }
            else if (health >= .25f && health < .7f)
            {
                SetImageFill(hpBar, health);
                SetImageColor(hpBar, Color.yellow);
            }
            else if (health > 0f && health < .25f)
            {
                SetImageFill(hpBar, health);
                SetImageColor(hpBar, Color.red);
            }

            else if (health <= 0)
                SetImageFill(hpBar, 0f);
        }

    
}
