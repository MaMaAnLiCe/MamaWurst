using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
using UnityEngine.UI;
using TMPro;


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
       
        LoginCanvas.SetActive(true);
        StartCoroutine(TypeWriter());
        yield return null;
    }


    public IEnumerator TypeWriter()

    {
        passwordTMP.text = "";
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
