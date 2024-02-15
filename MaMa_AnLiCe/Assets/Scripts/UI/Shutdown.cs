using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity; 

public class Shutdown : MonoBehaviour
{
    public float shutdownDuration;

    public EventReference shutdownSound;
    public void ShutDownButton()
    {
        StartCoroutine(ShutdownCoroutine());
    }

    public IEnumerator ShutdownCoroutine()
    {
        RuntimeManager.PlayOneShot(shutdownSound);    
        yield return new WaitForSeconds(shutdownDuration);
        Application.Quit();
    }
}
