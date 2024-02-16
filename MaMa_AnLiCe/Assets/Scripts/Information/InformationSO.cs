using FMODUnity;
using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;


[CreateAssetMenu(fileName = "Information")]
public class InformationSO : ScriptableObject
{
    [SerializeField] public int time;
    [SerializeField] public Location location; 
    [SerializeField] public InformationType infoType;
    [SerializeField] public List<PersonSO> person;
    [SerializeField] public bool revealed;
    [SerializeField] public Sprite propSprite;
    [SerializeField] public int interactionWeight;
    [SerializeField] public string content;
    [SerializeField] public string folderName;
    [SerializeField] public Sprite InformationImage;
    [SerializeField] public string shortDescription;

    [SerializeField] public EventReference MouseClick;

    [SortingLayer] public string sortingLayer;
    [SerializeField] public int OrderInSortingLayer;

}
