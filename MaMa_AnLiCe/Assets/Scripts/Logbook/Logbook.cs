using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Logbook: MonoBehaviour
{
    public static Logbook Instance;
    public List<InformationSO> gatheredInformations;

    public GameObject LogBookGameObject;
    public InformationFolder informationFolder;
    public List<InformationFolder> informationFolders;
    public List<GridLayoutGroup> workdays;

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
        informationFolders = new List<InformationFolder>();
        gatheredInformations = new List<InformationSO>();   

        foreach(SituationsSO situation in GameManager.Instance.situations)
        {
            foreach(InformationSO information in situation.Informations)
            {
                InformationSO info = information;
                InformationFolder newFolder = Instantiate(informationFolder, workdays[situation.time].transform);
                newFolder.SetUp(info);
                informationFolders.Add(newFolder);
            }
        }
    }


}
