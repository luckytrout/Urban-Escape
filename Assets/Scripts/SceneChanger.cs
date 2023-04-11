using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    // need to populate with the name of the next level (of the current level in the scene)
    [SerializeField] private string nextLevel;

    public void LoadScene(string sceneName){
        SceneManager.LoadScene(sceneName);
    }

    public void LoadNextLevel(){
        SceneManager.LoadScene(nextLevel);
    }

    public void LoadGameOver(){
        SceneManager.LoadSceneAsync("GameOverScene");
    }

    public void QuitGame()
    {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
        Application.Quit();
    }
}
