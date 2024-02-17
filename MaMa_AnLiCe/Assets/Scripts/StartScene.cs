using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
using UnityEngine.UI;
using TMPro;
using FMODUnity;


public class StartScene : MonoBehaviour
{
    [SerializeField] SettingsSO settingsSO;

    [SerializeField] public Image ButtonsUeberdeckung;

    [SerializeField] float buttonFadeDuration;
    [SerializeField] float startGameDuration;

    [SerializeField] GameObject LoginCanvas;
    [SerializeField] TextMeshProUGUI passwordTMP;
    [SerializeField] float currentTypeWriterDelay;
    string password;

    [SerializeField] GameObject Button; 
    [SerializeField] GameObject Logo; 
    [SerializeField] GameObject LoadingBar; 
    [SerializeField] GameObject Mask; 

    public EventReference typingSound;

    private void Awake()
    {
        FMODUnity.RuntimeManager.GetBus("bus:/").setVolume(settingsSO.MasterVolume);
        FMODUnity.RuntimeManager.GetBus("bus:/SFX").setVolume(settingsSO.SFXVolume);
        FMODUnity.RuntimeManager.GetBus("bus:/Story").setVolume(settingsSO.StoryVolume);

        password = passwordTMP.text;
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
        Button.SetActive(false);
        Logo.SetActive(false);
        LoadingBar.SetActive(false);
        Mask.SetActive(false);
        LoginCanvas.SetActive(true);
        StartCoroutine(TypeWriter());
        yield return null;
    }


    public IEnumerator TypeWriter()

    {
        passwordTMP.text = "";
        RuntimeManager.PlayOneShot(typingSound);
        yield return new WaitForSeconds(1f);
        

        foreach (char c in password)
        {
            passwordTMP.text += c;    
            yield return new WaitForSeconds(Random.Range(0.06f, 0.2f));
            
        }
        yield return new WaitForSeconds(startGameDuration);

        SceneManager.LoadScene("MainScene");
    }


}
