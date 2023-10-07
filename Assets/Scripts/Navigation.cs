using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Navigation : MonoBehaviour {
    ////Changing scene by scene name
    //public void ChangeScene(string sceneName){
    //    SceneManager.LoadScene(sceneName);
    //}

    //changing scene by number (order in build managenement)
    public void LoadScene(int i){
        SceneManager.LoadScene(i);
        }
    // Quit button function
    public void QuitGame(){
        Application.Quit();
    }
}