using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class AreaData  {

    [SerializeField] private AreaName areaName;
    [SerializeField] private List<SubAreaData> subAreaList;
    

    public AreaData(AreaName areaName, int minNumOfSubArea, int maxNumOfSubArea)
    {
        this.areaName = areaName;
        
        subAreaList = new List<SubAreaData>();
        this.areaName = areaName;
        int rand = Random.Range(minNumOfSubArea, maxNumOfSubArea);

        List<WeatherType> weatherList = DataLoadManager.Inst.GetWeatherTypeList();
        

        for (int i = 0; i < rand; i++)
        {
            int randomWeatherIndex = UnityEngine.Random.Range(0, weatherList.Count);

            WeatherType randWeather = weatherList[randomWeatherIndex]; 

            SubAreaData sub = new SubAreaData(areaName, i,randWeather);
            subAreaList.Add(sub);
        }
    }

    public AreaName AreaName
    {
        get
        {
            return areaName;
        }       
    }
    public List<SubAreaData> SubAreaList
    {
        get
        {
            return subAreaList;
        }       
    }
}
