using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class InformationSlice : MonoBehaviour
{
    public TextMeshProUGUI location;
    public TextMeshProUGUI time;
    public TextMeshProUGUI content;
    public Image informationImage;
    public Props prop;
    public InformationSO information;

    public void InformationSetUp(InformationSO information, Props prop)
    {
        if (information.revealed)
        {
            this.information = information;
            location.text = information.location.ToString();
            time.text = information.time.ToString();
            content.text = information.content;
            informationImage.sprite = information.InformationImage;
            this.prop = prop;
            prop.isrunning = true;

        }
    }

    public void InformationSetUp(InformationSO information)
    {
        if (information.revealed)
        {
            this.information = information;
            location.text = information.location.ToString();
            time.text = information.time.ToString();
            content.text = information.content;
            informationImage.sprite = information.InformationImage;

        }
    }

    public void SaveData()
    {
        if (prop != null)
        {
            prop.isrunning = false;
        }
        information.revealed = true;
        Destroy(gameObject);


    }

    public void DiscardData()
    {
        if (prop != null)
        {
            prop.isrunning = false;
        }
        foreach(InformationFolder folder in Logbook.Instance.informationFolders)
        {
            if(folder.myInfo == information)
            {
                Destroy(folder.gameObject);
                break;
            }
        }
        Destroy(gameObject);
    }
}
