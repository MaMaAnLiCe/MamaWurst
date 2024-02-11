using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Infotory : MonoBehaviour
{
    public static Infotory Instance;
    public List<InformationSO> gatheredInformations;


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }

        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        gatheredInformations = new List<InformationSO>();   
    }
}
