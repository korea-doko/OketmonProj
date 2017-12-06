using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrcGenerator : MonoBehaviour {

    private static OrcGenerator inst;

    public static OrcGenerator Inst
    {
        get
        {
            return inst;
        }
    }
    public OrcGenerator()
    {
        inst = this;
    }

    [SerializeField] private int nextOrcID;

    private void Start()
    {
        nextOrcID = 0;
    }

    public OrcData GenOrcData()
    {
        int randomRank = UnityEngine.Random.Range(0, 5);

        return GenOrcData((ERank)randomRank);
    }
    public OrcData GenOrcData(ERank _rank)
    {
        List<OrcName> orcNameList =  DataLoadManager.Inst.GetOrcNameList();
        int randName = UnityEngine.Random.Range(0, orcNameList.Count);
        OrcName randOrcName = orcNameList[randName];
        // 이름

        List<RaceType> raceTypeList = DataLoadManager.Inst.GetRaceTypeList();
        int randRace = UnityEngine.Random.Range(0, raceTypeList.Count);
        RaceType raceType = raceTypeList[randRace];
        // 부족 

        List<ClassType> classTypeList = DataLoadManager.Inst.GetClassTypeList();
        int randClass = UnityEngine.Random.Range(0, classTypeList.Count);
        ClassType classType = classTypeList[randClass];
        // 직업

        List<RankType> rankTypeList = DataLoadManager.Inst.GetRankTypeList();
        int randRank = UnityEngine.Random.Range(0, rankTypeList.Count);
        RankType rankType = rankTypeList[randRank];
        // 랭크
        // 랭크에 따라서 공격 타입, 방어 타입, 약점, 강점 등이 추가로 붙을 수 있음. 그것은
        // 아래에서 해야한다.

        switch (rankType.Rank)
        {
            case ERank.Normal:
                break;
            case ERank.Elite:
                break;
            case ERank.Cheif:
                break;
            case ERank.Overlord:
                break;
            case ERank.Legend:
                break;
            default:
                break;
        }


        OrcData orcData = new OrcData(nextOrcID++, randOrcName, raceType, rankType, classType);

        int randNumOfAtkType = UnityEngine.Random.Range(1, 4);
        List<AttackType> atkList = DataLoadManager.Inst.GetAttackTypeList();
        for(int i = 0; i < randNumOfAtkType;i++)
        {
            int rand = UnityEngine.Random.Range(0, atkList.Count);
            AttackType atkType = atkList[rand];
            orcData.SetAttackTypeList(atkType);
        }



        int randNumOfDefType = UnityEngine.Random.Range(1, 4);       
        List<DefenseType> defList = DataLoadManager.Inst.GetDefenseTypeList();
        for(int i = 0; i < randNumOfDefType;i++)
        {
            int rand = UnityEngine.Random.Range(0, defList.Count);
            DefenseType defType = defList[rand];
            orcData.SetDefenseTypeList(defType);
        }
        
        return orcData;
    }
}
