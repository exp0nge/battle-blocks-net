﻿using UnityEngine;
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
 
    void Update()
    {
            health = playerHealth.health / 100f;
     
            if (health >= .7f)
            {
                if (health > 1f)
                    health = 1f;
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
