using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour {

    public List<OrcData> orcDataList;

    private void Start()
    {
        orcDataList = new List<OrcData>();
    }

    // Update is called once per frame
    void Update () {

        if (Input.GetKeyDown(KeyCode.G))
            GenerateOrc();
	}

    private void GenerateOrc()
    {
        OrcData orc =  OrcGenerator.Inst.GenOrcData();
        orcDataList.Add(orc);
    }
}
