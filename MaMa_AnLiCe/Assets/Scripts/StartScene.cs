using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class StartScene : MonoBehaviour
{
    [SerializeField] SettingsSO settingsSO;

    private void Awake()
    {
        FMODUnity.RuntimeManager.GetBus("bus:/").setVolume(settingsSO.MasterVolume);
        FMODUnity.RuntimeManager.GetBus("bus:/SFX").setVolume(settingsSO.SFXVolume);
        FMODUnity.RuntimeManager.GetBus("bus:/Story").setVolume(settingsSO.StoryVolume);
    }


    public void OpenSettings()
    {
        SceneManager.LoadScene("SettingsScene", LoadSceneMode.Additive);
    }

    public void StartGame()
    {
        SceneManager.LoadScene("MainScene");
    }



}
