using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InformationFolder : MonoBehaviour, IPointerClickHandler
{
    public InformationSO myInfo;

    [SerializeField] InformationSlice DetailedInfoSlice;

    public Image folderImage;
    public TextMeshProUGUI folderText;

    [SerializeField] Sprite fullFolder;
    [SerializeField] Sprite emptyFolder;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (myInfo.revealed)
        {
            InformationSlice infoSlice = Instantiate(DetailedInfoSlice, UIManager.Instance.transform);
            infoSlice.InformationSetUp(myInfo);
        }
    }

    private void OnEnable()
    {
        if(myInfo != null)
        {
            folderImage.sprite = myInfo.revealed ? myInfo.InformationImage : emptyFolder;

            folderText.text = myInfo.revealed ? myInfo.title : "locked";
        }
        
    }

    public void SetUp(InformationSO information)
    {
        myInfo = information;

        folderImage.sprite = information.revealed ? fullFolder : emptyFolder;

        folderText.text = information.revealed ? information.title : "locked";
    }
}
