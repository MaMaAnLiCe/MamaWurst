using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class SettingsSO : ScriptableObject
{
    [SerializeField] public float MasterVolume;
    [SerializeField] public float StoryVolume;
    [SerializeField] public float SFXVolume;

    [SerializeField] public bool Fullscreen;
}
