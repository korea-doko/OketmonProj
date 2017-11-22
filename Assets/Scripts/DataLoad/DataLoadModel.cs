using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;

[System.Serializable]
public class DataLoadModel : MonoBehaviour
{

    [SerializeField] private ClassTypeModel classTypeModel;
    [SerializeField] private DefenseTypeModel defenseTypeModel;
    [SerializeField] private RankTypeModel rankTypeModel;
    [SerializeField] private AttackTypeModel attackTypeModel;
    [SerializeField] private RaceTypeModel raceTypeModel;
    [SerializeField] private OrcNameModel orcNameModel;
    [SerializeField] private AreaNameModel areaNameModel;

    public AreaNameModel AreaNameModel
    {
        get
        {
            return areaNameModel;
        }
    }
    public OrcNameModel OrcNameModel
    {
        get
        {
            return orcNameModel;
        }
    }
    public RaceTypeModel RaceTypeModel
    {
        get
        {
            return raceTypeModel;
        }
        
    }
    public AttackTypeModel AttackTypeModel
    {
        get
        {
            return attackTypeModel;
        }
    }
    public RankTypeModel RankTypeModel
    {
        get
        {
            return rankTypeModel;
        }
    }
    public ClassTypeModel ClassTypeModel
    {
        get
        {
            return classTypeModel;
        }
    }
    public DefenseTypeModel DefenseTypeModel
    {
        get
        {
            return defenseTypeModel;
        }

    }

    public void Awake()
    {

        attackTypeModel = new AttackTypeModel();
        attackTypeModel.Init();

        defenseTypeModel = new DefenseTypeModel();
        defenseTypeModel.Init();

        rankTypeModel = new RankTypeModel();
        rankTypeModel.Init();

        raceTypeModel = new RaceTypeModel();
        raceTypeModel.Init();

        orcNameModel = new OrcNameModel();
        orcNameModel.Init();

        areaNameModel = new AreaNameModel();
        areaNameModel.Init();

        classTypeModel = new ClassTypeModel();
        classTypeModel.Init();
    }



}
