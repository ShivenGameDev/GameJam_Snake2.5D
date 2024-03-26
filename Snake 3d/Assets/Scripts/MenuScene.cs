using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuScene : MonoBehaviour
{
    public void StartMenu()
    {
        SceneManager.LoadSceneAsync(0);
    }
    public void PlayGame()
    {
        SceneManager.LoadSceneAsync(2);
    }
    public void exit()
    {
        Application.Quit();
    }
    public void Instructions()
    {
        SceneManager.LoadSceneAsync(1);
    }
}
