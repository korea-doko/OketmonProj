using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EAttackType
{
    Normal,
    Fire,
    Poison,
    Curse,
    Ice,
    Lightning
}

[System.Serializable]
public class AttackType
{
    [SerializeField] private EAttackType etype;
    [SerializeField] private string koreanName;
    [SerializeField] private string desc;

    public AttackType(EAttackType etype, string koreanName, string desc)
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
    public EAttackType Etype
    {
        get
        {
            return etype;
        }

    }
}
