using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoaderOld : MonoBehaviour
{
    public void LoadNextScene()
    {
        var currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.buildIndex + 1);
    }

    public void LoadStartScene()
    {
        SceneManager.LoadScene(0);
        var gameStatus = FindObjectOfType<GameSession>();
        gameStatus.DestroyGameStatus();
    }
}
