using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System;

public class AreaModel : MonoBehaviour {

    [SerializeField] private List<AreaData> areaList;

    public List<AreaData> AreaList
    {
        get
        {
            return areaList;
        }   
    }

    internal void Init(int numOfCurArea, int minNumOfSubArea, int maxNumOfSubArea)
    {
        areaList = new List<AreaData>();

        List<AreaName> areaNameList = DataLoadManager.Inst.GetAreaNameList();

        for (int i = 0; i < numOfCurArea; i++)
        {
            AreaName areaName = areaNameList[i];

            AreaData areaData = new AreaData(areaName,minNumOfSubArea,maxNumOfSubArea);

            areaList.Add(areaData);
        }


    }


}
