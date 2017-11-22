using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public interface ISubAreaContainer
{
    event EventHandler<SubAreaPanelClickedArgs> OnSubAreaPanelClicked;
}

public class SubAreaContainer : MonoBehaviour, ISubAreaContainer {

    private int maxNumOfSubArea;
    public Transform subAreaPanelParent;

    private List<SubAreaPanel> subAreaPanelList;

    public SubAreaDetailPanel subAreaDetailPanel;
    public event EventHandler<SubAreaPanelClickedArgs> OnSubAreaPanelClicked;

    internal void Init(int maxNumOfSubArea)
    {
        this.maxNumOfSubArea = maxNumOfSubArea;

        InitSubAreaPanel();
        InitSubAreaDetailPanel();

        Hide();        
    }
    
 
    internal void Hide()
    {
        foreach (SubAreaPanel s in subAreaPanelList)
            s.Hide();

        this.gameObject.SetActive(false);
    }
    internal void Show(List<SubAreaData> subAreaList)
    {
        int len = subAreaList.Count;

        for(int i = 0; i < len;i++)
        {
            SubAreaPanel subPanel = subAreaPanelList[i];
            subPanel.Show(subAreaList[i]);
        }

        this.gameObject.SetActive(true);
    }


    private void InitSubAreaPanel()
    {
        subAreaPanelList = new List<SubAreaPanel>();

        GameObject areaPanelPrefab = Resources.Load("Area/SubAreaPanel") as GameObject;

        for (int i = 0; i < maxNumOfSubArea; i++)
        {
            SubAreaPanel ap = ((GameObject)Instantiate(areaPanelPrefab)).GetComponent<SubAreaPanel>();
            ap.transform.SetParent(subAreaPanelParent);
            ap.Init(i);
            ap.OnSubAreaPanelClicked += Ap_OnSubAreaPanelClicked;
            subAreaPanelList.Add(ap);
        }
    }

    internal void ShowSubAreaDetailPanel(SubAreaData subAreaData)
    {
        subAreaDetailPanel.Show(subAreaData);
    }


    private void InitSubAreaDetailPanel()
    {
        subAreaDetailPanel.Init();
        subAreaDetailPanel.Hide();
    }


    private void Ap_OnSubAreaPanelClicked(object sender, SubAreaPanelClickedArgs e)
    {
        OnSubAreaPanelClicked(this, e);
    }
}
