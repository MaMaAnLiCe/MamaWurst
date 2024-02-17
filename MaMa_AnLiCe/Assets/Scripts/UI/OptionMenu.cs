using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using FMODUnity;
using FMOD.Studio;
using Cinemachine;
using UnityEngine.Timeline;

public class OptionMenu : MonoBehaviour
{
    [SerializeField] SettingsSO settingsSO;
    //public GameObject mainMenuCanvas;
    //public Button backButton;

    public UnityEngine.UI.Toggle FullScreenToggle;

    public Slider BrightnessSlider;

    [FMODUnity.BankRef]
    public string MasterBank;

    [FMODUnity.BankRef]
    public string SFXBank;

    [BankRef] public string MusicBank;

    private Bus StoryBus;
    private Bus SFXBus;
    private Bus MasterBus;


    //[SerializeField] Bus MusicBus;

    [SerializeField] Slider MasterSlider;
    [SerializeField] Slider SFXSlider;
    [SerializeField] Slider MusicSlider;

    bool starting;

    private void Awake()
    {
        MasterBus = FMODUnity.RuntimeManager.GetBus("bus:/");
        SFXBus = FMODUnity.RuntimeManager.GetBus("bus:/SFX");
        StoryBus = FMODUnity.RuntimeManager.GetBus("bus:/Story"); 
        
        FullScreenToggle.isOn = settingsSO.Fullscreen;
        MasterSlider.value = settingsSO.MasterVolume;
        SFXSlider.value = settingsSO.SFXVolume;
        MusicSlider.value = settingsSO.StoryVolume;
    }

    void Start()
    {
        starting = true; 
        FullScreenToggle.isOn = settingsSO.Fullscreen;
        MasterSlider.value = settingsSO.MasterVolume;
        SFXSlider.value = settingsSO.SFXVolume;
        MusicSlider.value = settingsSO.StoryVolume;
        starting = false;
    }


    public void BackToMainMenu()
    {
        gameObject.SetActive(false);
        //mainMenuCanvas.SetActive(true);
    }

    public void SetMasterVolume()
    {
        MasterBus.setVolume(MasterSlider.value);
        settingsSO.MasterVolume = MasterSlider.value;
    }

    public void SetSFXVolume()
    {
        SFXBus.setVolume(SFXSlider.value); 
        settingsSO.SFXVolume = SFXSlider.value;
    }

    public void SetStoryVolume()
    {
        StoryBus.setVolume(MusicSlider.value);
        settingsSO.StoryVolume = MusicSlider.value;
    }

    public void SetFullscreen()
    {

    }
    public void FullScreen()
    {
        if (starting)
        {
            return;
        }
        if (FullScreenToggle.isOn)
        {
            Screen.fullScreenMode = FullScreenMode.FullScreenWindow;
        }
        else
        {
            Screen.fullScreenMode = FullScreenMode.Windowed;
        }
        settingsSO.Fullscreen = FullScreenToggle.isOn;
    }

    public void AdjustGamma()
    {
        Screen.brightness = BrightnessSlider.value;
    }

    public void CloseSettings()
    {
        SceneManager.UnloadSceneAsync("SettingsScene");
    }
}
