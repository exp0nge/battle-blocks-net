using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class EndgameScreen : UI_Screen {
    // Use this for initialization
    protected override void Start() {
        base.Start();
    }

    /// <summary>
    /// Reloads the current level;
    /// </summary>
    public void ReloadLevel() {
        SceneManager.LoadScene(1);
    }
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="sceneIndex"></param>
    public void ReturnToMainMenu(int sceneIndex) {
        SceneManager.LoadScene(sceneIndex);
    }
}
