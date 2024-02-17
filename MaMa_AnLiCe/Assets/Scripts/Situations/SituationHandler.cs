using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using DG.Tweening;

public class SituationHandler : MonoBehaviour
{
    public Props propPrefab;
    public Person personPrefab;
    public SpriteRenderer unclickablePrefab;

    public int maxInteractionCounter;
    public int currentInteractionCount;

    public SpriteRenderer LocationSpriteRenderer;

    public Sprite LocationASprite;
    public Sprite LocationBSprite;
    public Sprite LocationCSprite;


    [SerializeField] public List<Sprite> interactionSprite;
    public SpriteRenderer interactionCount;
    public float punchScale;

    private void Start()
    {
        Sequence sequence = DOTween.Sequence();

        sequence.Append(transform.DOPunchPosition(/*transform.position + */Vector3.up * punchScale, .1f/*,10*/).SetEase(Ease.Linear));

        sequence.SetLoops(-1);

        sequence.Play();


    }

    public void SetUp(SituationsSO situation)
    {
        currentInteractionCount = 0;
        maxInteractionCounter = situation.interactionCounter;

        interactionCount.sprite = interactionSprite[currentInteractionCount];

        switch (situation.location)
        {
            case Location.Marketing:
                LocationSpriteRenderer.sprite = LocationASprite;
                break;
            case Location.Production:
                LocationSpriteRenderer.sprite = LocationBSprite;
                break;
            case Location.Research:
                LocationSpriteRenderer.sprite = LocationCSprite;
                break;
        }


        foreach (InformationSO info in situation.Informations)
        {
            Props prop = Instantiate(propPrefab, transform);
            prop.SetUp(info);


        }

        foreach (PersonSO person in situation.persons)
        {
            Person personInstance = Instantiate(personPrefab, transform);
            personInstance.SetUp(person);
        }

        if (situation.unclickables.Count > 0)
        {
            foreach (UnClickables unclickable in situation.unclickables)
            {
                SpriteRenderer newUnclickable = Instantiate(unclickablePrefab, transform);
                newUnclickable.sprite = unclickable.prop;
                newUnclickable.sortingLayerName = unclickable.SortingLayer;
                newUnclickable.sortingOrder = unclickable.OrderInSortingLayer;
                newUnclickable.transform.position = unclickable.targetPosition;
            }
        }
    }

    public void ReduceInteractionCounter(int amount)
    {
        currentInteractionCount += amount;

        interactionCount.sprite = interactionSprite[Mathf.Clamp(currentInteractionCount, 0, maxInteractionCounter)];

        if (currentInteractionCount >= maxInteractionCounter)
        {
            StartCoroutine(Loading());
        }
    }

    public IEnumerator Loading()
    {
        RuntimeManager.PlayOneShot(UIManager.Instance.logbookLoadingSound);
        UIManager.Instance.ConfirmButton.gameObject.SetActive(false);
        UIManager.Instance.LoadingScreen.SetActive(true);
        yield return new WaitForSeconds(UIManager.Instance.loadingScreenDuration);
        UIManager.Instance.SwitchState((int)GameState.LogbookState);
        UIManager.Instance.LoadingScreen.SetActive(false);
        GameManager.Instance.NextDay();
        Destroy(gameObject);
        yield return null;
    }
}
