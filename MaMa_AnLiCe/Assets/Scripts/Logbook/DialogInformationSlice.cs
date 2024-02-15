using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using UnityEngine.UI;
using FMODUnity;


public class DialogInformationSlice : InformationSlice
{
    public DialogInormationSO dialoginfo;

    int lineIndex = 0;
    [SerializeField] float typeWriterDelay;
    float currentTypeWriterDelay;
    [SerializeField] Button continueButton;
    [SerializeField] Button skipButton;

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
        RuntimeManager.PlayOneShot(dialoginfo.dialogLines[lineIndex].person.brabbelSound);
        continueButton.gameObject.SetActive(false);
        skipButton.gameObject.SetActive(true);
        content.text = "";
        currentTypeWriterDelay = typeWriterDelay;
        foreach (char c in dialoginfo.dialogLines[lineIndex].line)
        {
            content.text += c;
            if(!c.Equals("<") || !c.Equals(">"))
            {
                yield return new WaitForSeconds(currentTypeWriterDelay);
            }
        }
        currentTypeWriterDelay = typeWriterDelay;
        skipButton.gameObject.SetActive(false);
        continueButton.gameObject.SetActive(true);
        lineIndex++;

    }

    public void skipCurrentLine()
    {
        currentTypeWriterDelay = 0;
    }
}
