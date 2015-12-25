using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Utilities.Singleton;

public class GameManager : Singleton<GameManager> {
    public Transform[] spawnPoints = new Transform[2];    
    public GameObject[] players = new GameObject[2];
    public float timer = 3f;
    public Text startText;
    public Text endText;
    public GameObject endScreenCanvas;

    private int playerNumber;
    
    // Use this for initialization
    private void Start() {
        SetUpPlayer();
        StartCoroutine("EnablePlayer");
    }
    
    /// <summary>
    /// Moves and translates each player's position to a set position.
    /// Additionally toggles active components to deactive in order to control player input.
    /// </summary>
    private void SetUpPlayer() {
        for (int i = 0; i < players.Length; i++) {
            players[i].transform.position = spawnPoints[i].position;
            players[i].SetActive(true);
        }
        ToggleMainComponents();
    }
    
    /// <summary>
    /// A coroutine which controls how long player inputs are disabled.
    /// </summary>
    private IEnumerator EnablePlayer() {
        startText.text = "GET READY!";           
        yield return new WaitForSeconds(timer);
        startText.text = "Round Start!";
        yield return new WaitForSeconds(1f);
        startText.text = "";
        ToggleMainComponents();
    }

    /// <summary>
    /// Toggles the state of activated components.
    /// </summary>
    private void ToggleMainComponents() {
        for (int i = 0; i < players.Length; i++) {
            players[i].GetComponent<Movement>().enabled = !players[i].GetComponent<Movement>().enabled;
            players[i].GetComponent<LaunchProjectile>().enabled = !players[i].GetComponent<LaunchProjectile>().enabled;
        }
    }

    /// <summary>
    /// Disable all components that include shooting and movement.
    /// </summary>
    private void DisableComponents() {
        for (int i = 0; i < players.Length; i++) {
            players[i].GetComponent<Movement>().enabled = false;
            players[i].GetComponent<LaunchProjectile>().enabled = false;
            players[i].GetComponent<BurstFire>().enabled = false;
        }
    }
    
    #region Public Methods
    /// <summary>
    /// Displays the endscreen and disables player controls.
    /// </summary>
    public void ShowEndScreen(int player) {
        DisableComponents();
        if (player == 1)
            player = 2;
        else
            player = 1;
        endText.text = "Player " + player + " wins!";            
        endScreenCanvas.SetActive(true);
    }
    #endregion    
}
