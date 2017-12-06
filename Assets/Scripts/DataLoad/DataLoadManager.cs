using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataLoadManager : MonoBehaviour
{
    public DataLoadModel model;

    private static DataLoadManager inst;
    public static DataLoadManager Inst
    {
        get
        {
            return inst;
        }        
    }
    public DataLoadManager()
    {
        inst = this;
    }
    
    public List<AreaName> GetAreaNameList()
    {
        return model.AreaNameModel.AreaNameList;
    }
    public List<OrcName> GetOrcNameList()
    {
        return model.OrcNameModel.OrcNameList;
    }
    public List<RaceType> GetRaceTypeList()
    {
        return model.RaceTypeModel.RaceList;
    }
    public List<AttackType> GetAttackTypeList()
    {
        return model.AttackTypeModel.AttackList;
    }
    public List<RankType> GetRankTypeList()
    {
        return model.RankTypeModel.RankList;
    }
    public List<ClassType> GetClassTypeList()
    {
        return model.ClassTypeModel.ClassList;
    }
    public List<DefenseType> GetDefenseTypeList()
    {
        return model.DefenseTypeModel.DefenseList;
    }
    public List<WeatherType> GetWeatherTypeList()
    {
        return model.WeatherTypeModel.WeatherList;
    }
}
