using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using FMODUnity;
using FMOD.Studio;
using Cinemachine;
using UnityEngine.Timeline;

public class OptionMenu : MonoBehaviour
{

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
        MasterBus = FMODUnity.RuntimeManager.GetBus("bus:/Story");

        SetMasterVolume();
        SetSFXVolume();
        SetStoryVolume();
    }

    void Start()
    {





        starting = true;
        FullScreenToggle.isOn = Screen.fullScreenMode == FullScreenMode.FullScreenWindow;
        //backButton.onCick.AddListener(BackToMainMenu);
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
    }

    public void SetSFXVolume()
    {
        SFXBus.setVolume(SFXSlider.value);
    }

    public void SetStoryVolume()
    {
        StoryBus.setVolume(MusicSlider.value);
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
