using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using FMODUnity;

public class CamButton : MonoBehaviour, IPointerClickHandler
{

    public Location location;

    [SerializeField] Image myImage;

    [SerializeField] Sprite CamWithActivity;
    [SerializeField] Sprite CamWithNOActivity;

    public EventReference nonInteractableSound;

    private void OnEnable()
    {
        myImage.sprite = GameManager.Instance.hasSituation(location) ? CamWithActivity : CamWithNOActivity;
    }


    public void OnPointerClick(PointerEventData eventData)
    {
        if (!GameManager.Instance.hasSituation(location))
        {
            RuntimeManager.PlayOneShot(nonInteractableSound);
            return;
        }
        int currentTime = GameManager.Instance.currentTime;
        GameManager.Instance.LoadSituation(location);

    }


}
