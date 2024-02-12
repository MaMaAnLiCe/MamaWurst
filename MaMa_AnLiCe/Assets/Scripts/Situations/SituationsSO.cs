using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Situation")]
public class SituationsSO : ScriptableObject
{
    [SerializeField] public int time;
    [SerializeField] public Location location;
    [SerializeField] public List<PersonSO> persons;
    [SerializeField] public List<InformationSO> Informations;
    [SerializeField] public int interactionCounter;

    public void UpdateInformation()
    {
        foreach(InformationSO info in Informations)
        {
            info.time = this.time;
            info.location = this.location;
        }
    }
}
