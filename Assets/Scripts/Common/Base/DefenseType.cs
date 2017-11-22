using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum EDefenseType
{
    None
, PhysicalImmune
, PoisonImmune
, FireImmune
, CurseImmune
, IceImmune
, LightningImmune
}

[System.Serializable]
public class DefenseType
{
    [SerializeField] private EDefenseType etype;
    [SerializeField] private string koreanName;
    [SerializeField] private string desc;

    public DefenseType(EDefenseType etype, string koreanName, string desc)
    {
        this.etype = etype;
        this.koreanName = koreanName;
        this.desc = desc;
    }

    public string Desc
    {
        get
        {
            return desc;
        }


    }
    public string KoreanName
    {
        get
        {
            return koreanName;
        }

    
    }
    public EDefenseType Etype
    {
        get
        {
            return etype;
        }

    
    }
}
