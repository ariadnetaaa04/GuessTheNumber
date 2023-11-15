using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public string Game;
    public string Options;
    public string MainMenu;
    public string HowToPlay;

    public void LoadGame()
    {
        SceneManager.LoadScene(Game);
    }

    public void LoadOptions()
    {
        SceneManager.LoadScene(Options);
    }
    public void LoadMenu()
    {
        SceneManager.LoadScene(MainMenu);
    }
    public void LoadHowToPlay()
    {
        SceneManager.LoadScene(HowToPlay);
    }

    public void Resume()
    {
        SceneManager.LoadScene(Game);
        Time.timeScale = 1f;
    }
}
