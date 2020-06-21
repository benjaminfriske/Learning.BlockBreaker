using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
    [SerializeField] int breakableBlocks = 0;

    private void Update()
    {
        if (breakableBlocks == 0)
        {
            var currentScene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(currentScene.buildIndex + 1);
        }
    }

    public void AddBlock()
    {
        breakableBlocks++;
    }

    public void RemoveBlock()
    {
        breakableBlocks--;
    }
}
