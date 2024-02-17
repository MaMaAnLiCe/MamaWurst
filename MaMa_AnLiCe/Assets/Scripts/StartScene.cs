using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
using UnityEngine.UI;


public class StartScene : MonoBehaviour
{
    [SerializeField] SettingsSO settingsSO;

    [SerializeField] public Image ButtonsUeberdeckung;

    [SerializeField] float buttonFadeDuration;
    [SerializeField] float startGameDuration;

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
        StartCoroutine(StartGameCoroutine());
    }

    public IEnumerator StartGameCoroutine()
    {
        ButtonsUeberdeckung.raycastTarget = true;
        ButtonsUeberdeckung.DOFade(1, buttonFadeDuration);

        yield return new WaitForSeconds(startGameDuration);

        SceneManager.LoadScene("MainScene");
    }



}
