using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class AreaPanelClickedArgs : EventArgs
{
    public int clickedAreaPanelIndex;

    public AreaPanelClickedArgs(int index)
    {
        clickedAreaPanelIndex = index;
    }
}

public interface IAreaPanel
{
    event EventHandler<AreaPanelClickedArgs> OnAreaPanelClicked;
}
public class AreaPanel : MonoBehaviour, IAreaPanel
{
    public Text nameText;
    public Text weatherText;
    public Text terrainText;
    public Text completeText;
    public Button intoSubAreaButton;
    public int areaPanelIndex;

    public event EventHandler<AreaPanelClickedArgs> OnAreaPanelClicked;

    internal void Init(int areaPanelIndex)
    {
        this.areaPanelIndex = areaPanelIndex;
        intoSubAreaButton.onClick.AddListener(() => { AreaPanelClicked(); });
    }

    public void AreaPanelClicked()
    {
        OnAreaPanelClicked(this, new AreaPanelClickedArgs(areaPanelIndex));
    }
}
