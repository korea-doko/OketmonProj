using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerModel : MonoBehaviour
{
    public List<OrcData> playerOrcList;

	
    internal void Init()
    {
        playerOrcList = new List<OrcData>();

        for(int i = 0; i < 5;i++)
        {
            OrcData data = OrcGenerator.Inst.GenOrcData();
            playerOrcList.Add(data);
        }
    }
}
