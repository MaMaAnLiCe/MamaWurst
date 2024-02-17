using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

[CreateAssetMenu(fileName = "Person")]
public class PersonSO : ScriptableObject
{
    [SerializeField] public Sprite PersonSprite;
    public EventReference brabbelSound;

    [SerializeField] public Sprite portraitSprite;

    [SerializeField] public Vector3 targetPosition;

}
