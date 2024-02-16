using FMODUnity;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEmitterScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    internal void Initialize(EventReference brabbelSound)
    {
        GetComponent<FMODUnity.StudioEventEmitter>().EventReference = brabbelSound;
        GetComponent<FMODUnity.StudioEventEmitter>().Play();
    }
}
