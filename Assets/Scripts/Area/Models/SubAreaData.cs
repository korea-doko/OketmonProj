using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class SubAreaData {

    [SerializeField] private AreaName areaName;
    [SerializeField] private int number;

    [SerializeField] private WeatherType weatherType;
    
    [SerializeField] private List<OrcData> enemyOrcList;
    [SerializeField] private int limitNumOfPlayerOrc;
    [SerializeField] private OrcData[] playerOrcAry;
    
    public SubAreaData(AreaName areaName, int i)
    {
        enemyOrcList = new List<OrcData>();
              
        int maxNumOfOrc = 3;

        int numOrc = UnityEngine.Random.Range(1, maxNumOfOrc + 1);
        limitNumOfPlayerOrc = UnityEngine.Random.Range(1, maxNumOfOrc + 1);

        playerOrcAry = new OrcData[limitNumOfPlayerOrc];
          
        for (int num = 0; num < numOrc; num++)
        {
            OrcData data = OrcGenerator.Inst.GenOrcData();
            enemyOrcList.Add(data);
        }

        this.areaName = areaName;
        this.number = i;
    }
    public SubAreaData(AreaName areaName, int i, WeatherType randWeather) : this(areaName, i)
    {
        this.weatherType = randWeather;        
    }

    public void AddPlayerOrcData(int index,OrcData data)
    {
        if (index >= limitNumOfPlayerOrc)
            Debug.Log("에러");
       
        for(int i = 0; i < limitNumOfPlayerOrc;i++)
        {
            OrcData od = playerOrcAry[i];

            if (od == null)
                continue;

            if( od.genID == data.genID)
            {
                playerOrcAry[i] = null;
                break;
            }
        }

        playerOrcAry[index] = data;
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
    public OrcData[] PlayerOrcAry
    {
        get
        {
            return playerOrcAry;
        }
    }
    public WeatherType WeatherType
    {
        get
        {
            return weatherType;
        }
    }
}
