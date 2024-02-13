using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DetailedInfoSlice : InformationSlice
{
    public TextMeshProUGUI detailedInfo;
    public override void InformationSetUp(InformationSO information)
    {
        base.InformationSetUp(information);
        detailedInfo.text = information.content;
    }
}
