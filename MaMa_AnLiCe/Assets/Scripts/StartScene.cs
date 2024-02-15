using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class StartScene : MonoBehaviour
{


    public void OpenSettings()
    {
        SceneManager.LoadScene("SettingsScene", LoadSceneMode.Additive);
    }

    public void StartGame()
    {
        SceneManager.LoadScene("MainScene");
    }

 
 
}
