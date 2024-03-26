using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class EndScene : MonoBehaviour
{
    
    public void PlayAgain(){
        SceneManager.LoadSceneAsync(0);
    }
    public void exit(){
        Application.Quit();
    }
}
