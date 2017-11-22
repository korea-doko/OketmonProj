using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ERaceType
{
    NoTribe,
    BlackStone,
    WarSong,
    FrostFang,
    BlackMoon,
    BloodTear,
    BrokenHand,
    DragonHunt,
    BoneCrush
}
[System.Serializable]
public class RaceType
{
    public ERaceType raceType;
    public string koreanName;
    public string desc;
    
    public RaceType(ERaceType _raceType, string _koreanName , string _desc)
    {
        raceType = _raceType;
        koreanName = _koreanName;
        desc = _desc;
    }
}
