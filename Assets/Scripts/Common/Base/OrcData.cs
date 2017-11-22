using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[System.Serializable]
public class OrcData
{
    public OrcName name;
    public RaceType raceType;
    public RankType rankType;
    public ClassType classType;


    public AttackType[] attackTypeAry;
    public DefenseType[] defenseTypeAry;



    public OrcData(OrcName _name, RaceType _raceType, RankType _rankType,
        ClassType _classType, AttackType[] _attackTypeAry, DefenseType[] _defenseTypeAry)
    {
        name = _name;
        raceType = _raceType;
        rankType = _rankType;
        classType = _classType;

        attackTypeAry = _attackTypeAry;
        defenseTypeAry = _defenseTypeAry;
    }

    public string GetTestInfo()
    {
        string str = "";

        str += name.name + "\n";
        str += raceType.koreanName + "\n";
        str += rankType.KoreanName + "\n";
        str += classType.KoreanName + "\n";

        foreach (AttackType at in attackTypeAry)
            str += at.KoreanName + "\n";

        foreach (DefenseType dt in defenseTypeAry)
            str += dt.KoreanName + "\n";


        return str;
    }
}
