using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class CamButton : MonoBehaviour, IPointerClickHandler
{

    public Location location;


    public void OnPointerClick(PointerEventData eventData)
    {
        int currentTime = GameManager.Instance.currentTime;
        GameManager.Instance.LoadSituation(location);
    }

   
}
