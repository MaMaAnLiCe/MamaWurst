using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class Props : MonoBehaviour, IPointerClickHandler
{
    public InformationSO propInfo;
    public SituationManager situationManager;

    public void OnPointerClick(PointerEventData eventData)
    {
        StartCoroutine(InformationGathering());
    }

    public void SetUp(InformationSO information)
    {
        propInfo = information;
        GetComponent<SpriteRenderer>().sprite = information.propSprite;
        gameObject.AddComponent<PolygonCollider2D>();
    }

    private IEnumerator InformationGathering()
    {
        Infotory.Instance.gatheredInformations.Add(propInfo);
        gameObject.GetComponent<PolygonCollider2D>().enabled = false;
        situationManager.ReduceInteractionCounter(propInfo.interactionWeight);
        yield return null;
    }

}
