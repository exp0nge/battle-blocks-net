using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class StartScreen : UI_Screen {

    public void StartGame(int level)
    {
        SceneManager.LoadScene(level);
    }

}
