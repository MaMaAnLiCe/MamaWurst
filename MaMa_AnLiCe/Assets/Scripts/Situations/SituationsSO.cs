using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Situation")]
public class SituationsSO : ScriptableObject
{
    [SerializeField] public int time;
    [SerializeField] public Location location;
    [SerializeField] public List<SituationsPerson> persons;
    [SerializeField] public int interactionCounter;







}
