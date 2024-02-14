using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogInformationSlice : InformationSlice
{
    public DialogInormationSO dialoginfo;

    int lineIndex = 0;
    [SerializeField] float typeWriterDelay;
    [SerializeField] Button continueButton;

    public override void InformationSetUp(InformationSO information, Props prop)
    {
        if (information.revealed)
        {
            this.information = information;
            this.dialoginfo = information as DialogInormationSO;
            TypeNextLine();

            this.prop = prop;
            prop.isrunning = true;
        }
    }

    public void TypeNextLine()
    {
        if(lineIndex == dialoginfo.dialogLines.Count)
        {
            prop.isrunning = false;
            dialoginfo.revealed = true; 
            Destroy(gameObject);
        }
        else
        {
            informationImage.sprite = dialoginfo.dialogLines[lineIndex].person.PersonSprite;
            StartCoroutine(TypeWriter());
        }
        
    }

    public IEnumerator TypeWriter()
    {
        continueButton.gameObject.SetActive(false);
        content.text = "";
        foreach (char c in dialoginfo.dialogLines[lineIndex].line)
        {
            content.text += c;
            if(!c.Equals("<") || !c.Equals(">"))
            {
                yield return new WaitForSeconds(typeWriterDelay);
            }
        }

        continueButton.gameObject.SetActive(true);
        lineIndex++;
    }
}
