using UnityEngine;
using System.Collections;

public class SceneLoading : MonoBehaviour {

    public void loadNextLevel(int levelToLoad) {
        Application.LoadLevel(levelToLoad);
    }
}
