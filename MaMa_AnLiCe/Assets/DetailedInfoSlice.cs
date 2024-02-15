using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DetailedInfoSlice : InformationSlice
{
    public TextMeshProUGUI TitleTMP;
    public override void InformationSetUp(InformationSO information)
    {
        base.InformationSetUp(information);
        TitleTMP.text = information.folderName;
        content.text = information.content;
    }
}
