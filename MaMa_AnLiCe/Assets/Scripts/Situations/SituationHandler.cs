using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class SituationHandler : MonoBehaviour
{
    public Props propPrefab;
    public Person personPrefab;

    public int maxInteractionCounter;
    public int currentInteractionCount;

    public SpriteRenderer LocationSpriteRenderer;

    public Sprite LocationASprite;
    public Sprite LocationBSprite;
    public Sprite LocationCSprite;


    [SerializeField] public List<Sprite> interactionSprite;
    public SpriteRenderer interactionCount;

    

  
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

        foreach(PersonSO person in situation.persons)
        {
            Person personInstance = Instantiate(personPrefab, transform);
            personInstance.SetUp(person);
        }

        
    }

    public void ReduceInteractionCounter(int amount)
    {
        currentInteractionCount += amount;

        interactionCount.sprite = interactionSprite[Mathf.Clamp(currentInteractionCount, 0, maxInteractionCounter)];

        if(currentInteractionCount >= maxInteractionCounter )
        {
            StartCoroutine(Loading());
        }
    }

    public IEnumerator Loading()
    {
        RuntimeManager.PlayOneShot(UIManager.Instance.logbookLoadingSound);
        UIManager.Instance.LoadingScreen.SetActive(true);
        yield return new WaitForSeconds(UIManager.Instance.loadingScreenDuration);
        UIManager.Instance.LoadingScreen.SetActive(false);
        GameManager.Instance.NextDay();
        Destroy(gameObject);
        yield return null;
    }
}
