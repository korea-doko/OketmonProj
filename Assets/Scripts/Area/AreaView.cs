using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public interface IAreaView
{
    event EventHandler<AreaPanelClickedArgs> OnAreaPanelClicked;
    event EventHandler<SubAreaPanelClickedArgs> OnSubAreaPanelClicked;
}

public class AreaView : MonoBehaviour, IAreaView {

    public AreaContainer areaContainer;
    public SubAreaContainer subAreaContainer;


    public event EventHandler<AreaPanelClickedArgs> OnAreaPanelClicked;
    public event EventHandler<SubAreaPanelClickedArgs> OnSubAreaPanelClicked;

    internal void Init(int numOfCurArea, int maxNumOfSubArea)
    {
        areaContainer.Init(numOfCurArea);
        areaContainer.OnAreaPanelClicked += AreaContainer_OnAreaPanelClicked;

        subAreaContainer.Init(maxNumOfSubArea);
        subAreaContainer.OnSubAreaPanelClicked += SubAreaContainer_OnSubAreaPanelClicked;
    }

   

    internal void ShowArea(AreaModel model)
    {
        areaContainer.Show();
    }
    internal void HideArea()
    {
        areaContainer.Hide();
    }
    internal void ShowSubArea(AreaData areaData)
    {
        subAreaContainer.Show(areaData.SubAreaList);
    }
    private void AreaContainer_OnAreaPanelClicked(object sender, AreaPanelClickedArgs e)
    {
        OnAreaPanelClicked(this, e);
    }
    private void SubAreaContainer_OnSubAreaPanelClicked(object sender, SubAreaPanelClickedArgs e)
    {
        OnSubAreaPanelClicked(this, e);
    }

    internal void ShowSubAreaDetailPanel(SubAreaData subAreaData)
    {
        subAreaContainer.ShowSubAreaDetailPanel(subAreaData);
    }
}
