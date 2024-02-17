using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using UnityEngine.SceneManagement;

public class Shutdown : MonoBehaviour
{
    public float shutdownDuration;

    public EventReference shutdownSound;

    public GameObject ShutdownConfirmation;

    public void ShutDownButton()
    {
        ShutdownConfirmation.SetActive(true);
    }

    public void QuitGame()
    {
        StartCoroutine(ShutdownCoroutine());
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("StartScene");
    }

    public IEnumerator ShutdownCoroutine()
    {
        RuntimeManager.PlayOneShot(shutdownSound);    
        yield return new WaitForSeconds(shutdownDuration);
        Application.Quit();
    }
}
