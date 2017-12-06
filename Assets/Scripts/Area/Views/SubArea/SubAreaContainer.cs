using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public interface ISubAreaContainer
{
    event EventHandler<SubAreaPanelClickedArgs> OnSubAreaPanelClicked;
    event EventHandler<SubAreaPlayerOrcPanelArgs> OnSubAreaPlayerOrcPanelClicked;
    event EventHandler<SubAreaPlayerOrcSelectPanelArgs> OnSubAreaPlayerOrcSelectPanelClicked;
    event EventHandler OnSubAreaDetailPanelExcuteButtonClicked;
}

public class SubAreaContainer : MonoBehaviour, ISubAreaContainer {

    private int maxNumOfSubArea;
    public Transform subAreaPanelParent;

    private List<SubAreaPanel> subAreaPanelList;
    public SubAreaDetailPanel subAreaDetailPanel;

    public event EventHandler<SubAreaPanelClickedArgs> OnSubAreaPanelClicked;
    public event EventHandler<SubAreaPlayerOrcPanelArgs> OnSubAreaPlayerOrcPanelClicked;
    public event EventHandler<SubAreaPlayerOrcSelectPanelArgs> OnSubAreaPlayerOrcSelectPanelClicked;
    public event EventHandler OnSubAreaDetailPanelExcuteButtonClicked;

    internal void Init(int maxNumOfSubArea)
    {
        this.maxNumOfSubArea = maxNumOfSubArea;

        InitSubAreaPanel();
        InitSubAreaDetailPanel();

        Hide();        
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
    private void InitSubAreaDetailPanel()
    {
        subAreaDetailPanel.Init();

        subAreaDetailPanel.OnSubAreaPlayerOrcPanelClicked += SubAreaDetailPanel_OnSubAreaPlayerOrcPanelClicked;
        subAreaDetailPanel.OnSubAreaPlayerOrcSelectPanelClicked += SubAreaDetailPanel_OnSubAreaPlayerOrcSelectPanelClicked;
        subAreaDetailPanel.OnSubAreaDetailPanelExcuteButtonClicked += SubAreaDetailPanel_OnSubAreaDetailPanelExcuteButtonClicked;

        subAreaDetailPanel.Hide();
    }

    private void SubAreaDetailPanel_OnSubAreaDetailPanelExcuteButtonClicked(object sender, EventArgs e)
    {
        OnSubAreaDetailPanelExcuteButtonClicked(this, e);
    }
    private void SubAreaDetailPanel_OnSubAreaPlayerOrcSelectPanelClicked(object sender, SubAreaPlayerOrcSelectPanelArgs e)
    {
        OnSubAreaPlayerOrcSelectPanelClicked(this, e);
    }
    private void Ap_OnSubAreaPanelClicked(object sender, SubAreaPanelClickedArgs e)
    {
        OnSubAreaPanelClicked(this, e);
    }
    private void SubAreaDetailPanel_OnSubAreaPlayerOrcPanelClicked(object sender, SubAreaPlayerOrcPanelArgs e)
    {
        OnSubAreaPlayerOrcPanelClicked(this, e);
    }

    internal void HideSubAreaPlayerOrcSelectPanel()
    {
        subAreaDetailPanel.HideSubAreaPlayerOrcSelectPanel();
    }
    internal void Hide()
    {
        foreach (SubAreaPanel s in subAreaPanelList)
            s.Hide();

        this.gameObject.SetActive(false);
    }
    internal void ShowSubAreaPlayerOrcSelectContainer(List<OrcData> playerOrcDataList)
    {
        subAreaDetailPanel.ShowSubAreaPlayerOrcSelectContainer(playerOrcDataList);
    }
    internal void Show(List<SubAreaData> subAreaList)
    {
        int len = subAreaList.Count;

        for (int i = 0; i < len; i++)
        {
            SubAreaPanel subPanel = subAreaPanelList[i];
            subPanel.Show(subAreaList[i]);
        }

        this.gameObject.SetActive(true);
    }
    internal void ShowSubAreaDetailPanel(SubAreaData subAreaData)
    {
        subAreaDetailPanel.Show(subAreaData);
    }
    

}
