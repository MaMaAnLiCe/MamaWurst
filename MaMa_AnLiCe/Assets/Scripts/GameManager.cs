using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public int dayCount = 5;
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

    internal void NextDay()
    {
        currentTime++;
        date.text = daysOfTheWeek[currentTime];
        if(currentTime >= dayCount)
        {
            // game is over yo.
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
}
