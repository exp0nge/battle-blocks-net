using UnityEngine;
using System.Collections;
#if UNITY_5_3
using UnityEngine.SceneManagement;
#endif

public class StartScreen : UI_Screen {
#if UNITY_5_3
    /// <summary>
    /// Loads the next subsequent scene.
    /// </summary>
    /// <param name="level">Int value, scene number to load</param>
    public void StartGame(int level)
    {
        SceneManager.LoadScene(level);
    }
#endif
    /// <summary>
    /// Close and exit the application.
    /// </summary>
    public void QuitGame() {
        Application.Quit();
    }

}
