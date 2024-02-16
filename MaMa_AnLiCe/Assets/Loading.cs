using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Loading : MonoBehaviour
{
    public RectTransform loadingBar;
    public float endValue;
    float startValue;

    // Update is called once per frame
    void Start()
    {
        startValue = loadingBar.position.x;

        Sequence sequence = DOTween.Sequence();
        sequence.Append(loadingBar.DOLocalMoveX(endValue,3f).SetEase(Ease.Linear));
        sequence.Insert(4f,loadingBar.DOLocalMoveX(startValue, 0f));
        


        sequence.SetLoops(-1);
        sequence.Play();


    }




}
