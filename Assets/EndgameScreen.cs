using UnityEngine;
using System.Collections;

public class EndgameScreen : UI_Screen {
    public float health;
    public Health playerHealth;
    public string gameOver = "Gameover";
    // Use this for initialization
    protected override void Start()
    {
        base.Start();
    }
    
    void Update () {
        health = playerHealth.health / 100f;
        if (health <= 0f)
        {
            if (health < 0f) {
                health = 0f;
            }
            SetText(gameOver, "U lost scrub");
        }
    }
}
