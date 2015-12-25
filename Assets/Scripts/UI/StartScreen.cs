using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class StartScreen : UI_Screen {

    /// <summary>
    /// Loads the next subsequent scene.
    /// </summary>
    /// <param name="level">Int value, scene number to load</param>
    public void StartGame(int level)
    {
        SceneManager.LoadScene(level);
    }

}
