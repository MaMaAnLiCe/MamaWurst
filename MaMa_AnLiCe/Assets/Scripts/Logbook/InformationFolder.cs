using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InformationFolder : MonoBehaviour, IPointerClickHandler
{
    public InformationSO myInfo;

    [SerializeField] InformationSlice InformationSlicePrefab;

    public Image folderImage;
    public TextMeshProUGUI folderText;

    [SerializeField] Sprite fullFolder;
    [SerializeField] Sprite emptyFolder;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (myInfo.revealed)
        {
            InformationSlice infoSlice = Instantiate(InformationSlicePrefab,UIManager.Instance.transform);
            infoSlice.InformationSetUp(myInfo);
        }
    }

    public void SetUp(InformationSO information)
    {
        myInfo = information;

        folderImage.sprite = information.revealed ? fullFolder : emptyFolder;

        folderText.text = information.revealed ? information.folderName : "locked";
    }
}
