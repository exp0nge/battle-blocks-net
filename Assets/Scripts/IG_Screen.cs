using UnityEngine;
using System.Collections;

public class IGscreen: UI_Screen {
    public float health;
    public string hpBar = "HP_Bar";
    //public string gameOver = "Gameover";
    // Use this for initialization
    protected override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    void Update () {
        health = (GetComponent<Health>().health) / 100 ;
        //fillHealth = health / 100;
        SetImageFill(hpBar, health);
        if (health >= 70)
            SetImageColor(hpBar, Color.red);
        else if (health >= 25 && health < 70)
            SetImageColor(hpBar, Color.yellow);
        else if (health > 0 && health < 25)
            SetImageColor(hpBar, Color.red);
        //else if (health <= 0)
        //    SetText(gameOver,"U lost nub");
	
	}
}
