using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using FMODUnity;
using UnityEngine.EventSystems;


public class WeekdayButton : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] public Sprite unlockedButton;
    [SerializeField] public Image folderimage;

    bool blocked = true;


    public EventReference nonInteractable;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (blocked)
        {
            FMODUnity.RuntimeManager.PlayOneShot(nonInteractable);
        }
        Debug.Log("LOL");
    }

    public void Unlock()
    {
        folderimage.sprite = unlockedButton;
        gameObject.GetComponent<Button>().interactable = true;
        blocked = false;
    }
}
