using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class UnClickables : ScriptableObject
{
    [SerializeField] public Sprite prop;

    [NaughtyAttributes.SortingLayer] public string SortingLayer;
    [SerializeField] public int OrderInSortingLayer;
    [SerializeField] public Vector3 targetPosition;
}
