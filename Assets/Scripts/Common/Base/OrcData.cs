using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[System.Serializable]
public class OrcData
{
    public int genID;

    public OrcName name;
    public RaceType raceType;
    public RankType rankType;
    public ClassType classType;
    
    public List<AttackType> attackTypeList;
    public List<DefenseType> defenseTypeList;


    public OrcData(int _genID,OrcName _name, RaceType _raceType, RankType _rankType,
        ClassType _classType)
    {

        attackTypeList = new List<AttackType>();
        defenseTypeList = new List<DefenseType>();

        genID = _genID;

        name = _name;
        raceType = _raceType;
        rankType = _rankType;
        classType = _classType;      
    }
    public void SetAttackTypeList(AttackType attackType)
    {

        if (!CheckAlreadyHasAttackType(attackType))
            attackTypeList.Add(attackType);
        
    }
    public void SetDefenseTypeList(DefenseType defenseType)
    {
        if (!CheckAlreadyHasDefenseType(defenseType))
            defenseTypeList.Add(defenseType);

    }

    public string GetTestInfo()
    {
        string str = "";

        str += name.name + "\n";
        str += raceType.koreanName + "\n";
        str += rankType.KoreanName + "\n";
        str += classType.KoreanName + "\n";

        Debug.Log(attackTypeList.Count + "_" + defenseTypeList.Count);

        for (int i = 0; i < attackTypeList.Count; i++)
            str += attackTypeList[i].KoreanName + "\n";

        for (int i = 0; i < defenseTypeList.Count; i++)
            str += defenseTypeList[i].KoreanName + "\n";
        
        return str;
    }

    private bool CheckAlreadyHasAttackType(AttackType _type)
    {
        for (int i = 0; i < attackTypeList.Count; i++)
        {
            if (attackTypeList[i].Etype == _type.Etype)
                return true;
        }

        return false;
    }
    private bool CheckAlreadyHasDefenseType(DefenseType _type)
    {
        for (int i = 0; i < defenseTypeList.Count; i++)
        {
            if (defenseTypeList[i].Etype == _type.Etype)
                return true;
        }

        return false;
    }
}
