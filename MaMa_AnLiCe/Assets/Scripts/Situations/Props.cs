using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using FMODUnity;

public class Props : MonoBehaviour, IPointerClickHandler
{
    public InformationSO propInfo;
    public InformationSlice informationSlice;
    public DialogInformationSlice dialogInformationSlice;
    public bool isrunning;

    private void OnMouseDown()
    {
        
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        propInfo.revealed = true;
        StartCoroutine(InformationGathering());
        InformationSlice infoSlice;
        if (propInfo is DialogInormationSO)
        {
            infoSlice = Instantiate(dialogInformationSlice, UIManager.Instance.transform);
        }
        else
        {
            infoSlice = Instantiate(informationSlice, UIManager.Instance.transform);
        }
        
        infoSlice.InformationSetUp(propInfo, this);
        GetComponent<FMODUnity.StudioEventEmitter>().Play();
    }

    public void SetUp(InformationSO information)
    {
        propInfo = information;
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sortingLayerName = propInfo.sortingLayer;
        spriteRenderer.sortingOrder = propInfo.OrderInSortingLayer;
        spriteRenderer.sprite = information.propSprite;
        gameObject.AddComponent<PolygonCollider2D>();
        GetComponent<StudioEventEmitter>().EventReference = information.MouseClick;
        transform.position = information.targetPosition;
    }

    private IEnumerator InformationGathering()
    {
        isrunning = true; 
        while (isrunning)
        {
            yield return null;
        }
        Logbook.Instance.gatheredInformations.Add(propInfo);
        gameObject.GetComponent<PolygonCollider2D>().enabled = false;


        GetComponentInParent<SituationHandler>().ReduceInteractionCounter(propInfo.interactionWeight);
        yield return null;
    }

}
