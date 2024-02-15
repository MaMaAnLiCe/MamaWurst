using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using FMODUnity;
using FMOD.Studio;

public class OptionMenu : MonoBehaviour
{

    //public GameObject mainMenuCanvas;
    //public Button backButton;

    public UnityEngine.UI.Toggle FullScreenToggle;

    public Slider BrightnessSlider;

    [FMODUnity.BankRef]
    public string SFXBank;

    [SerializeField] Bus SFXBus;

    [FMODUnity.BankRef]
    public string MasterBank;

    [SerializeField] Bus MusicBus;

    [SerializeField] Slider SFXSlider;
    [SerializeField] Slider MusicSlider;

    bool starting;

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

    }

    public void SetSFXVolume()
    {
        SFXBus.setVolume(SFXSlider.value);
    }

    public void SetMusicVolume()
    {

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
