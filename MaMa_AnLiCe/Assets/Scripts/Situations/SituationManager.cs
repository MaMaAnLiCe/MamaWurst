using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SituationManager : MonoBehaviour
{
    public Props propPrefab;
    public int interactionCounter;

    public void SetUp(SituationsSO situation)
    {
        interactionCounter = situation.interactionCounter;
        
        foreach (SituationsPerson sp in situation.persons)
        {
            Props prop = Instantiate(propPrefab, transform);
            prop.SetUp(sp.informations);
        }
    }

    public void ReduceInteractionCounter(int amount)
    {
        interactionCounter -= amount;

        if(interactionCounter <=0)
        {
            Destroy(gameObject);
        }
    }
}
