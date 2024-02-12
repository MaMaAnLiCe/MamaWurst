using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SituationManager : MonoBehaviour
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

        
        foreach (SituationsPerson sp in situation.persons)
        {
            Props prop = Instantiate(propPrefab, transform);
            prop.SetUp(sp.informations);

            Person person = Instantiate(personPrefab,transform);
            person.SetUp(sp.person);
        }
    }

    public void ReduceInteractionCounter(int amount)
    {
        interactionCounter -= amount;

        if(interactionCounter <=0)
        {
            Destroy(gameObject);
        }
    }
}
