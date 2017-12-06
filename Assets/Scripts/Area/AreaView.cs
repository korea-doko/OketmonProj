using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public interface IAreaView
{
    event EventHandler<AreaPanelClickedArgs> OnAreaPanelClicked;
    event EventHandler<SubAreaPanelClickedArgs> OnSubAreaPanelClicked;
    event EventHandler<SubAreaPlayerOrcPanelArgs> OnSubAreaPlayerOrcPanelClicked;
    event EventHandler<SubAreaPlayerOrcSelectPanelArgs> OnSubAreaPlayerOrcSelectPanelClicked;
    event EventHandler OnSubAreaDetailPanelExcuteButtonClicked;
}

public class AreaView : MonoBehaviour, IAreaView {

    public AreaContainer areaContainer;
    public SubAreaContainer subAreaContainer;


    public event EventHandler<AreaPanelClickedArgs> OnAreaPanelClicked;
    public event EventHandler<SubAreaPanelClickedArgs> OnSubAreaPanelClicked;
    public event EventHandler<SubAreaPlayerOrcPanelArgs> OnSubAreaPlayerOrcPanelClicked;
    public event EventHandler<SubAreaPlayerOrcSelectPanelArgs> OnSubAreaPlayerOrcSelectPanelClicked;
    public event EventHandler OnSubAreaDetailPanelExcuteButtonClicked;

    internal void Init(int numOfCurArea, int maxNumOfSubArea)
    {
        areaContainer.Init(numOfCurArea);
        areaContainer.OnAreaPanelClicked += AreaContainer_OnAreaPanelClicked;

        subAreaContainer.Init(maxNumOfSubArea);
        subAreaContainer.OnSubAreaPanelClicked += SubAreaContainer_OnSubAreaPanelClicked;
        subAreaContainer.OnSubAreaPlayerOrcPanelClicked += SubAreaContainer_OnSubAreaPlayerOrcPanelClicked;
        subAreaContainer.OnSubAreaPlayerOrcSelectPanelClicked += SubAreaContainer_OnSubAreaPlayerOrcSelectPanelClicked;
        subAreaContainer.OnSubAreaDetailPanelExcuteButtonClicked += SubAreaContainer_OnSubAreaDetailPanelExcuteButtonClicked;
    }

    private void SubAreaContainer_OnSubAreaDetailPanelExcuteButtonClicked(object sender, EventArgs e)
    {
        OnSubAreaDetailPanelExcuteButtonClicked(this, e);
    }
    private void SubAreaContainer_OnSubAreaPlayerOrcSelectPanelClicked(object sender, SubAreaPlayerOrcSelectPanelArgs e)
    {
        OnSubAreaPlayerOrcSelectPanelClicked(this, e);
    }
    private void AreaContainer_OnAreaPanelClicked(object sender, AreaPanelClickedArgs e)
    {
        OnAreaPanelClicked(this, e);
    }
    private void SubAreaContainer_OnSubAreaPanelClicked(object sender, SubAreaPanelClickedArgs e)
    {
        OnSubAreaPanelClicked(this, e);
    }
    private void SubAreaContainer_OnSubAreaPlayerOrcPanelClicked(object sender, SubAreaPlayerOrcPanelArgs e)
    {
        OnSubAreaPlayerOrcPanelClicked(this, e);
    }

    internal void ShowArea(AreaModel model)
    {
        areaContainer.Show();
    }
    internal void HideSubAreaPlayerOrcSelectPanel()
    {
        subAreaContainer.HideSubAreaPlayerOrcSelectPanel();
    }
    internal void HideArea()
    {
        areaContainer.Hide();
    }
    internal void ShowSubArea(AreaData areaData)
    {
        subAreaContainer.Show(areaData.SubAreaList);
    }
    internal void ShowSubAreaDetailPanel(SubAreaData subAreaData)
    {
        subAreaContainer.ShowSubAreaDetailPanel(subAreaData);
    }   
    internal void ShowSubAreaPlayerOrcSelectContainer(List<OrcData> playerOrcDataList)
    {
        subAreaContainer.ShowSubAreaPlayerOrcSelectContainer(playerOrcDataList);
    }
}
