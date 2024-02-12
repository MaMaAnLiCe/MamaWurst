using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum GameState
{
    CamButtonState,
    SituationsState,
    LogbookState,
    LogbookSituationState
}

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    public GameObject CamButtonCanvas;
    public GameObject LogbookCanvas;
    public GameObject SituationCanvas;

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
                break;

            case GameState.SituationsState:
                CamButtonCanvas.SetActive(false);
                LogbookCanvas.SetActive(false);
                SituationCanvas.SetActive(true);

                break;

            case GameState.LogbookState:
                CamButtonCanvas.SetActive(false);
                SituationCanvas.SetActive(false);               
                LogbookCanvas.SetActive(true);
                CamButton.interactable = true;
                ConfirmButton.gameObject.SetActive(false);
                break;

            case GameState.LogbookSituationState:

                CamButtonCanvas.SetActive(false);
                SituationCanvas.SetActive(false);
                LogbookCanvas.SetActive(true);
                CamButton.interactable = false;
                ConfirmButton.gameObject.SetActive(true);
                break; 
        }
        currentState = (GameState)newState;
    }
}
