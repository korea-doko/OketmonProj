using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyOrcPanelContainer : MonoBehaviour {

    public List<EnemyOrcPanel> enemyOrcPanelList;

    internal void Init()
    {
        foreach (EnemyOrcPanel p in enemyOrcPanelList)
            p.Init();
    }

    internal void Show(List<OrcData> orcDataList)
    {
        HideOrcPanel();

        int count = orcDataList.Count;

        for(int i = 0; i < count;i++)
        {
            OrcData data = orcDataList[i];
            EnemyOrcPanel op = enemyOrcPanelList[i];

            op.Show(data);
        }
    }

    private void HideOrcPanel()
    {
        foreach (EnemyOrcPanel p in enemyOrcPanelList)
            p.Hide();
    }

}
