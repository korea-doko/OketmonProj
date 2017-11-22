using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SubAreaPanelClickedArgs : EventArgs
{
    public int index;

    public SubAreaPanelClickedArgs(int _index)
    {
        index = _index;
    }
}

public interface ISubAreaPanel
{
    event EventHandler<SubAreaPanelClickedArgs> OnSubAreaPanelClicked;
}

public class SubAreaPanel : MonoBehaviour , ISubAreaPanel{


    public int id;
    public Text terrainText;

    public event EventHandler<SubAreaPanelClickedArgs> OnSubAreaPanelClicked;

    internal void Init(int i)
    {
        id = i;
    }
    internal void Show(SubAreaData subAreaData)
    {
        terrainText.text = subAreaData.AreaName.name +"_"+ subAreaData.Number.ToString();
        this.gameObject.SetActive(true);
    }
    internal void Hide()
    {
        this.gameObject.SetActive(false);
    }

    public void Clicked()
    {
        OnSubAreaPanelClicked(this, new SubAreaPanelClickedArgs(id));
    }
}
