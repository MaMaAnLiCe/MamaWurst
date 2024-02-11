using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Information")]
public class InformationSO : ScriptableObject
{
    [SerializeField] public InformationType infoType;
    [SerializeField] public List<PersonSO> person;
    [SerializeField] public bool revealed;
    [SerializeField] public Sprite propSprite;
    [SerializeField] public int interactionWeight;
}
