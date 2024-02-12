using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SituationsPerson
{
    public PersonSO person;


    //[Dropdown("Informations")]
    public List<InformationSO> informations;



    //private DropdownList<InformationSO> Informations()
    //{
    //    try
    //    {
    //        DropdownList<InformationSO> result = new DropdownList<InformationSO>();
    //        foreach (InformationSO info in person.information)
    //        {
    //            result.Add(info.name, info);
    //        }
    //        return result;
    //    }

    //    catch
    //    {
    //        return new DropdownList<InformationSO>();
    //    }
    //}
}




/*[System.Serializable]
public class situationsPersonInformation
{
    PersonSO person;

    [Dropdown("Information")]
    public string information;

    private List<string> Information { get { return new List<string>() { "hallo", "welte" }; } }
}
*/