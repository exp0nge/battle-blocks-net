using UnityEngine;
#if UNITY_5_3
using UnityEngine.SceneManagement;
#endif
using System.Collections;

public class EndgameScreen : UI_Screen {
    // Use this for initialization
    protected override void Start() {
        base.Start();
    }
#if UNITY_5_3
    /// <summary>
    /// Reloads the current level;
    /// </summary>
    public void ReloadLevel() {
        SceneManager.LoadScene(1);
    }
    
    /// <summary>
    /// Loads the main scene.
    /// </summary>
    /// <param name="sceneIndex">Scene to load.</param>
    public void ReturnToMainMenu(int sceneIndex) {
        SceneManager.LoadScene(sceneIndex);
    }
#endif
}
