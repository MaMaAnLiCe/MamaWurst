using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public int dayCount = 4;
    public int currentTime;
    public List<SituationsSO> situations;
    public SituationHandler SituationPrefab;
    public TextMeshProUGUI date;
    [SerializeField] public List<string> daysOfTheWeek;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }

        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        ResetAllInformations();
        date.text = daysOfTheWeek[currentTime];
    }

    public void LoadSituation(Location location)
    {
        foreach(SituationsSO situation in situations)
        {
            if(location == situation.location && currentTime == situation.time)
            {
                SituationHandler situationPrefab = Instantiate(SituationPrefab);
                situationPrefab.SetUp(situation);
                situation.UpdateInformation();
            }

        }

        UIManager.Instance.SwitchState((int)GameState.SituationsState);
    }

    public bool hasSituation(Location location)
    {
        foreach(SituationsSO situation in situations)
        {
            if(location == situation.location && currentTime == situation.time)
            {
                return true;
            }
        }
        return false;
    }

    public void NextDay()
    {
        currentTime++;
        if(currentTime >= dayCount)
        {
            
            UIManager.Instance.SwitchState((int) GameState.EndOfWeekState);
        }
        else
        {
            
            UIManager.Instance.SwitchState((int) GameState.LogbookState);
        }
        try
        {
            date.text = daysOfTheWeek[currentTime];
        }
        catch
        {
            date.text = daysOfTheWeek[0];
        }
       
    }

    public void ResetAllInformations()
    {
        foreach (SituationsSO situation in situations)
        {
           foreach(InformationSO info in situation.Informations)
            {
                info.revealed = false;
            }

        }
    }

    public void ReplayFootage()
    {
        currentTime = 0;
        UIManager.Instance.SwitchState((int)GameState.CamButtonState);
    }

    public void Report()
    {
        SceneManager.LoadScene("StartScene");
    }
}
