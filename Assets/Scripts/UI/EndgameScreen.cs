using UnityEngine;
using System.Collections;

public class EndgameScreen : UI_Screen {
    //public Rigidbody playerRigidBody;
    public float health;
    public Health playerHealth;
    public string gameOver = "Gameover";
    // Use this for initialization
    protected override void Start()
    {
        base.Start();
    }
    //void Awake()
    //{
    //    playerRigidBody = GetComponent<Rigidbody>();
    //}
    // Update is called once per frame
    void Update () {
        health = playerHealth.health / 100f;
        if (health <= 0f)
        {
            OpenThisScreen();
            SetText(gameOver, "U lost nub");
        }
    }
}
