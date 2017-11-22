using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class SubAreaData {

    [SerializeField] private AreaName areaName;
    [SerializeField] private int number;

    [SerializeField] private List<OrcData> enemyOrcList;

    [SerializeField] private int limitNumOfPlayerOrc;
    [SerializeField] private List<OrcData> playerOrcList;

    public SubAreaData(AreaName areaName, int i)
    {
        enemyOrcList = new List<OrcData>();
        playerOrcList = new List<OrcData>();

       
        int maxNumOfOrc = 3;

        int numOrc = UnityEngine.Random.Range(1, maxNumOfOrc + 1);
        limitNumOfPlayerOrc = UnityEngine.Random.Range(1, maxNumOfOrc + 1);

        for (int num = 0; num < numOrc; num++)
        {
            OrcData data = OrcGenerator.Inst.GenOrcData();
            enemyOrcList.Add(data);
        }

        this.areaName = areaName;
        this.number = i;
    }


    public AreaName AreaName
    {
        get
        {
            return areaName;
        }
    }
    public int Number
    {
        get
        {
            return number;
        }
    }
    public List<OrcData> EnemyOrcList
    {
        get
        {
            return enemyOrcList;
        }
    }
    public int LimitNumOfPlayerOrc
    {
        get
        {
            return limitNumOfPlayerOrc;
        }
    }
    public List<OrcData> PlayerOrcList
    {
        get
        {
            return playerOrcList;
        }
    }
}
