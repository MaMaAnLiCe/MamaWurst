using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using FMODUnity;

public enum GameState
{
    CamButtonState,
    SituationsState,
    LogbookState,
    LogbookSituationState, 
    EndOfWeekState
}

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    public GameObject CamButtonCanvas;
    public GameObject LogbookCanvas;
    public GameObject SituationCanvas;
    public GameObject EndCanvas;
    public GameObject LoadingScreen;

    public GameState currentState;
    public Button ConfirmButton;
    public Button CamButton;

    public EventReference situationLoadingSound; 
    public EventReference logbookLoadingSound;

    public float loadingScreenDuration;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SwitchState(int newState)

    {
        switch ((GameState)newState)
        {
            case GameState.CamButtonState:
                CamButtonCanvas.SetActive(true);
                LogbookCanvas.SetActive(false);
                SituationCanvas.SetActive(false);
                EndCanvas.SetActive(false);
                break;

            case GameState.SituationsState:
                if(currentState == GameState.CamButtonState)
                {
                    StartCoroutine(Loading());
                } 
                else
                {
                    LoadingScreen.SetActive(false);
                    CamButtonCanvas.SetActive(false);
                    LogbookCanvas.SetActive(false);
                    SituationCanvas.SetActive(true);
                    EndCanvas.SetActive(false); 
                    ConfirmButton.gameObject.SetActive(false);
                }

                break;

            case GameState.LogbookState:
                CamButtonCanvas.SetActive(false);
                SituationCanvas.SetActive(false);               
                LogbookCanvas.SetActive(true);
                EndCanvas.SetActive(false);
                CamButton.interactable = true;
                break;

            case GameState.LogbookSituationState:
                GameManager.Instance.DaySelected(GameManager.Instance.currentTime);
                CamButtonCanvas.SetActive(false);
                SituationCanvas.SetActive(false);
                LogbookCanvas.SetActive(true);
                EndCanvas.SetActive(false);
                ConfirmButton.gameObject.SetActive(true);
                CamButton.interactable = false;
                break;


            case GameState.EndOfWeekState:
                CamButtonCanvas.SetActive(false);
                SituationCanvas.SetActive(false);
                LogbookCanvas.SetActive(false);
                EndCanvas.SetActive(true);
                break;

        }
        currentState = (GameState)newState;
    }

    public void OpenSettings()
    {
        SceneManager.LoadScene("SettingsScene", LoadSceneMode.Additive);
    }


    public IEnumerator Loading()
    {
        LoadingScreen.SetActive(true);
        RuntimeManager.PlayOneShot(situationLoadingSound);
        yield return new WaitForSeconds(loadingScreenDuration);
        LoadingScreen.SetActive(false);
        CamButtonCanvas.SetActive(false);
        LogbookCanvas.SetActive(false);
        SituationCanvas.SetActive(true);
        EndCanvas.SetActive(false);
        ConfirmButton.gameObject.SetActive(false);
    }
}
