using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using DG.Tweening;

public class InformationSlice : MonoBehaviour
{
    public TextMeshProUGUI location;
    public TextMeshProUGUI time;
    public TextMeshProUGUI content;
    public Image informationImage;
    public Props prop;
    public InformationSO information;
    public Vector3 logbookButton;

    public TextMeshProUGUI FolderNameText;

    public virtual void InformationSetUp(InformationSO information, Props prop)
    {
        if (information.revealed)
        {
            this.information = information;
            location.text = information.location.ToString();
            time.text = GameManager.Instance.daysOfTheWeek[information.time];
            try
            {
                content.text = information.shortDescription;
            }
            catch
            {

            }

            informationImage.sprite = information.InformationImage;
            this.prop = prop;
            prop.isrunning = true;

            FolderNameText.text = information.folderName;

        }
    }

    public virtual void InformationSetUp(InformationSO information)
    {
        if (information.revealed)
        {
            this.information = information;
            location.text = information.location.ToString();
            time.text = GameManager.Instance.daysOfTheWeek[information.time];
            content.text = information.shortDescription;
            informationImage.sprite = information.InformationImage;

        }
    }

    public void SaveData()
    {
        if(this is DetailedInfoSlice)
        {
            SaveDataLogic();
        }
        else
        {
            Sequence sequence = DOTween.Sequence();
            sequence.Append(transform.DOLocalMove(logbookButton, 0.2f).SetEase(Ease.Linear));
            sequence.Insert(0f, GetComponent<RectTransform>().DOScale(0, 0.2f).SetEase(Ease.Linear));
            sequence.OnComplete(() => SaveDataLogic());
            sequence.Play();
        }
    }

    public void SaveDataLogic()
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
        foreach (InformationFolder folder in Logbook.Instance.informationFolders)
        {
            if (folder.myInfo == information)
            {
                Destroy(folder.gameObject);
                break;
            }
        }
        Destroy(gameObject);
    }
}
