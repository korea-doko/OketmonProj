using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SubAreaDetailPanel : MonoBehaviour {

    public Button closeButton;

    public EnemyOrcPanelContainer enemyOrcPanelContainer;




    internal void Init()
    {
        enemyOrcPanelContainer.Init();
    }
    
    public void Hide()
    {
        this.gameObject.SetActive(false);
    }

    public void CloseButtonClicked()
    {
        Hide();
    }

    internal void Show(SubAreaData subAreaData)
    {
        List<OrcData> orcDataList = subAreaData.EnemyOrcList;
        enemyOrcPanelContainer.Show(orcDataList);
        this.gameObject.SetActive(true);
    }
}
