using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public const int Start = 0;
    public const int LevelSelect = 1;
    GameState gs;

    public void NextScene()
    {
        // Scene loading, based on index

        int sceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (sceneIndex == Start)
        {
            // Go to level 1 if on Start scene
            SceneManager.LoadScene(sceneIndex + 2);
        }
        else
        {
            // go to next level
            SceneManager.LoadScene(sceneIndex + 1);
        }
    }

    public void StartScene()
    {
        // Load initial scene
        SceneManager.LoadScene(Start);
        gs = FindObjectOfType<GameState>();
        if (gs != null)
        {
            gs.Restart();
        }
    }

    public void GoToScene(int level)
    {
        // Go to level
        SceneManager.LoadScene(LevelSelect + level);
    }

    public void LevelScene()
    {
        SceneManager.LoadScene(Start + 1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void GameOver()
    {
        SceneManager.LoadScene("End");
    }
}
