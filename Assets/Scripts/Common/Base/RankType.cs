using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum ERank
{
    Normal,
    Elite,
    Cheif,
    Overlord,
    Legend
}

[System.Serializable]
public class RankType
{
    [SerializeField] private ERank rank;
    [SerializeField] private string koreanName;
    [SerializeField] private string desc;


    public RankType(ERank _rank, string koreanName, string desc)
    {
        this.rank = _rank;
        this.koreanName = koreanName;
        this.desc = desc;
    }

    public ERank Rank
    {
        get
        {
            return rank;
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
