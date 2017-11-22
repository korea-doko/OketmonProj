using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public enum EClassType
{
    Assassin,
    Berserker,
    BeastMaster,
    Commander,
    Destroyer,
    Tracer,
    Tanker,
    Archer,
    Trickster,
    Mystic
}
[System.Serializable]
public class ClassType
{
    [SerializeField] private EClassType etype;
    [SerializeField] private string koreanName;
    [SerializeField] private string desc;

    public ClassType(EClassType etype, string koreanName, string desc)
    {
        this.etype = etype;
        this.koreanName = koreanName;
        this.desc = desc;
    }

    public EClassType Etype
    {
        get
        {
            return etype;
        }
    }
    public string KoreanName
    {
        get
        {
            return koreanName;
        }

    }
    public string Desc
    {
        get
        {
            return desc;
        }
    }
}
