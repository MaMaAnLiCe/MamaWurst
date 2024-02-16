using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using FMODUnity;


public class WeekdayButton : MonoBehaviour
{
    [SerializeField] public Sprite unlockedButton;
    [SerializeField] public Image folderimage;

    public EventReference nonInteractable;



    public void Unlock()
    {
        folderimage.sprite = unlockedButton;
        gameObject.GetComponent<Button>().interactable = true;  
    }
}
