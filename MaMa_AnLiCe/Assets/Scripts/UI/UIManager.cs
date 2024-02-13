using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    public GameState currentState;
    public Button ConfirmButton;
    public Button CamButton;

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
                CamButtonCanvas.SetActive(false);
                LogbookCanvas.SetActive(false);
                SituationCanvas.SetActive(true);
                EndCanvas.SetActive(false);
                ConfirmButton.gameObject.SetActive(false);



                break;

            case GameState.LogbookState:
                CamButtonCanvas.SetActive(false);
                SituationCanvas.SetActive(false);               
                LogbookCanvas.SetActive(true);
                EndCanvas.SetActive(false);
                CamButton.interactable = true;
                break;

            case GameState.LogbookSituationState:

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
}
