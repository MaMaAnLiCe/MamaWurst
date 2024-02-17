using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Person : MonoBehaviour
{
    [SerializeField] SpriteRenderer PersonSpriteRenderer;

    public void SetUp(PersonSO person)
    {
        PersonSpriteRenderer.sprite = person.PersonSprite;
        transform.position = person.targetPosition;
    }
}
