using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

        interactionCount.sprite = interactionSprite[currentInteractionCount];

        if(currentInteractionCount >= maxInteractionCounter )
        {
            GameManager.Instance.NextDay();
            UIManager.Instance.SwitchState(2);
            Destroy(gameObject);
        }
    }
}
