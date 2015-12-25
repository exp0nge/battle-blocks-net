using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public Transform[] spawnPoints = new Transform[2];    
    public GameObject[] players = new GameObject[2];
    public float timer = 3f;
    public Text roundText;
    
    // Use this for initialization
    private void Start() {
        SetUpPlayer();
        StartCoroutine("EnablePlayer");
    }
    
    /// <summary>
    /// Moves and translates each player's position to a set position.
    /// </summary>
    private void SetUpPlayer() {
        for (int i = 0; i < players.Length; i++) {
            players[i].transform.position = spawnPoints[i].position;
            players[i].SetActive(true);
            players[i].GetComponent<Movement>().enabled = !players[i].GetComponent<Movement>().enabled;
        }
    }
    
    private IEnumerator EnablePlayer() {
        yield return new WaitForSeconds(timer);
        roundText.text = "Round Start!";
        yield return new WaitForSeconds(1f);
        roundText.text = "";
        for (int i = 0; i < players.Length; i++) {
            players[i].GetComponent<Movement>().enabled = !players[i].GetComponent<Movement>().enabled;
        }
    }
}
