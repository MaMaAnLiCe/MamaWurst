using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeekdayButton : MonoBehaviour
{
    [SerializeField] public Sprite unlockedButton;
    [SerializeField] public Image folderimage;


    public void Unlock()
    {
        folderimage.sprite = unlockedButton;
        gameObject.GetComponent<Button>().interactable = true;
        
    }
}
