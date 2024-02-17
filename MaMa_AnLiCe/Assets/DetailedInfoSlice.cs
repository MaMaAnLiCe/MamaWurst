using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG;
using DG.Tweening;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class DetailedInfoSlice : InformationSlice
{
    public TextMeshProUGUI TitleTMP;

    public GameObject DetailedInfoSliceContent;
    public override void InformationSetUp(InformationSO information)
    {
        base.InformationSetUp(information);
        TitleTMP.text = information.folderName;
        content.text = information.content;

        DetailedInfoSliceContent.gameObject.GetComponent<RectTransform>().DOScale(Vector3.one, .15f).From(Vector3.zero).SetEase(Ease.OutCirc);

        if (information is DialogInormationSO)
        {
            informationImage.gameObject.SetActive(false);
        }
    }
}
