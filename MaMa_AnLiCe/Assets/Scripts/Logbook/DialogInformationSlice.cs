using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using UnityEngine.UI;
using FMODUnity;
using DG.Tweening;


public class DialogInformationSlice : InformationSlice
{
    public DialogInormationSO dialoginfo;

    public SoundEmitterScript DialogSoundEmitterPrefab;

    int lineIndex = 0;
    [SerializeField] float typeWriterDelay;
    float currentTypeWriterDelay;
    [SerializeField] Button continueButton;
    [SerializeField] Button skipButton;
    public StudioEventEmitter emitter;

    [SerializeField] float tweenScaleStrength;
    [SerializeField] Vector3 tweenMoveStrength;
    [SerializeField] float Tweenduration;
    [SerializeField] Ease tweenScaleEase;
    [SerializeField] Ease tweenMoveEase;


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

        Sequence sequence = DOTween.Sequence();

        //sequence.Append(continueButton.transform.DOScale(continueButton.transform.localScale + Vector3.one * tweenScaleStrength, Tweenduration / 2));
        //sequence.Append(continueButton.transform.DOScale(continueButton.transform.localScale - Vector3.one * tweenScaleStrength, Tweenduration / 2));
        sequence.Append(continueButton.transform.DOPunchScale(Vector3.one * tweenScaleStrength, Tweenduration).SetEase(tweenScaleEase));
        sequence.Insert(0,skipButton.transform.DOPunchScale(Vector3.one * tweenScaleStrength, Tweenduration).SetEase(tweenScaleEase));

        sequence.Insert(0, continueButton.transform.DOPunchPosition(tweenMoveStrength, Tweenduration).SetEase(tweenMoveEase));
        sequence.Insert(0, skipButton.transform.DOPunchPosition(tweenMoveStrength, Tweenduration).SetEase(tweenMoveEase));

        //sequence.Insert(0, continueButton.transform.DOMove(continueButton.transform.position + tweenMoveStrength, Tweenduration / 2));
        //sequence.Insert(Tweenduration / 2, continueButton.transform.DOMove(continueButton.transform.position - tweenMoveStrength, Tweenduration / 2));

        sequence.SetLoops(-1);
        sequence.Play();


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
        SoundEmitterScript brabel = Instantiate(DialogSoundEmitterPrefab);
        brabel.Initialize(dialoginfo.dialogLines[lineIndex].person.brabbelSound);

        //emitter.EventReference = dialoginfo.dialogLines[lineIndex].person.brabbelSound;
        //Debug.Log(emitter.EventReference.Path);
        //emitter.Play();
        //RuntimeManager.PlayOneShot(dialoginfo.dialogLines[lineIndex].person.brabbelSound);
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
        Destroy(brabel.gameObject);
        
        currentTypeWriterDelay = typeWriterDelay;
        skipButton.gameObject.SetActive(false);
        continueButton.gameObject.SetActive(true);
        lineIndex++;
        yield return null;
    }

    public void skipCurrentLine()
    {
        currentTypeWriterDelay = 0;
    }
}
