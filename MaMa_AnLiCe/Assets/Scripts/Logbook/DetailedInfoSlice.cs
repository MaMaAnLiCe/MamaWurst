using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DetailedInfoSlice : InformationSlice
{

    public TextMeshProUGUI title;


    public override void InformationSetUp(InformationSO information)
    {
        base.InformationSetUp(information);
        title.text = information.title;
    }
}
