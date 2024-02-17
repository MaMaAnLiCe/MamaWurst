using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameEndReport : MonoBehaviour
{
    [SerializeField] Button EndButton;

    [SerializeField] Ease easingFunction;
    [SerializeField] float tweenduration;
    [SerializeField] int SpinAmount;

    // Start is called before the first frame update
    void Start()
    {
        EndButton.gameObject.SetActive(false);

        gameObject.transform.DOScale(1, tweenduration);
        Sequence sequence = DOTween.Sequence();
        sequence.Append(gameObject.transform.DOLocalRotate(Vector3.back * 360*SpinAmount, tweenduration,RotateMode.FastBeyond360));
        sequence.SetLoops(SpinAmount);
        sequence.OnComplete(()=> EndButton.gameObject.SetActive(true));
        sequence.Play();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
