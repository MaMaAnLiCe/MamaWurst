using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SituationHandler : MonoBehaviour
{
    public Props propPrefab;
    public Person personPrefab;

    public int interactionCounter;

    public SpriteRenderer LocationSpriteRenderer;

    public Sprite LocationASprite;
    public Sprite LocationBSprite;
    public Sprite LocationCSprite;

    public void SetUp(SituationsSO situation)
    {
        interactionCounter = situation.interactionCounter;

        switch (situation.location)
        {
            case Location.A:
                LocationSpriteRenderer.sprite = LocationASprite;
                break;
            case Location.B:
                LocationSpriteRenderer.sprite = LocationBSprite;
                break;
            case Location.C:
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
        interactionCounter -= amount;

        if(interactionCounter <=0)
        {
            GameManager.Instance.NextDay();
            UIManager.Instance.SwitchState(2);
            Destroy(gameObject);
        }
    }
}
