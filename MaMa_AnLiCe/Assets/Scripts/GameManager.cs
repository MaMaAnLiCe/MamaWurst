using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public int currentTime;
    public List<SituationsSO> situations;
    public SituationManager SituationPrefab;

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

    public void LoadSituation(Location location)
    {
        foreach(SituationsSO situation in situations)
        {
            if(location == situation.location && currentTime == situation.time)
            {
                SituationManager situationPrefab = Instantiate(SituationPrefab);
                situationPrefab.SetUp(situation);

            }

        }
    }
    


}
