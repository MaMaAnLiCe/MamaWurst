using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Person")]
public class PersonSO : ScriptableObject
{
    [SerializeField] public Sprite PersonSprite;
}
