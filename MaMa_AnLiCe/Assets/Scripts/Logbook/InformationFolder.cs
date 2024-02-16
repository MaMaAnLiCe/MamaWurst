using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using FMODUnity;
public class InformationFolder : MonoBehaviour, IPointerClickHandler
{
    public InformationSO myInfo;

    [SerializeField] InformationSlice DetailedInfoSlice;

    public EventReference nonInteractable;

    public Image folderImage;
    public TextMeshProUGUI folderText;

    [SerializeField] Sprite fullFolder;
    [SerializeField] Sprite emptyFolder;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (myInfo.revealed)
        {
            InformationSlice infoSlice = Instantiate(DetailedInfoSlice,UIManager.Instance.transform);
            infoSlice.InformationSetUp(myInfo);
            RuntimeManager.PlayOneShot(myInfo.MouseClick);

        }

        else
        {
            RuntimeManager.PlayOneShot(nonInteractable);
        }
    }

    private void OnEnable()
    {
        if(myInfo != null)
        {
            folderImage.sprite = myInfo.revealed ? myInfo.InformationImage : emptyFolder;

            folderText.text = myInfo.revealed ? myInfo.folderName : "locked";
        }
        
    }

    public void SetUp(InformationSO information)
    {
        myInfo = information;

        folderImage.sprite = information.revealed ? myInfo.InformationImage : emptyFolder;

        folderText.text = information.revealed ? information.folderName : "locked";
    }
}
