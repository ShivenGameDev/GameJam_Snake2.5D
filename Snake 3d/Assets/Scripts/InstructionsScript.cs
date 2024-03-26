using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;
public class InstructionsScript : MonoBehaviour
{
    public void PlayAgain(){
        SceneManager.LoadSceneAsync(0);
    }
    public void Instruction(){
        SceneManager.LoadSceneAsync(4);
    }
    public void exit(){
        Application.Quit();
    }}
