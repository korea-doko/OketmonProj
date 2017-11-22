using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public interface IAreaContainer
{
    event EventHandler<AreaPanelClickedArgs> OnAreaPanelClicked;
}

public class AreaContainer : MonoBehaviour, IAreaContainer {


    public Transform areaPanelParent;

    public List<AreaPanel> areaPanelList;

    public event EventHandler<AreaPanelClickedArgs> OnAreaPanelClicked;

    internal void Init(int numOfCurArea)
    {
        areaPanelList = new List<AreaPanel>();

        GameObject areaPanelPrefab = Resources.Load("Area/AreaPanel") as GameObject;

        for (int i = 0; i < numOfCurArea;i++)
        {

            AreaPanel ap = ((GameObject)Instantiate(areaPanelPrefab)).GetComponent<AreaPanel>();
            ap.transform.SetParent(areaPanelParent);
            ap.Init(i);
            ap.OnAreaPanelClicked += Ap_OnAreaPanelClicked;
            areaPanelList.Add(ap);
        }

        Hide();
    }

    
    public void Hide()
    {
        this.gameObject.SetActive(false);
    }
    public void Show()
    {
        this.gameObject.SetActive(true);
    }


    private void Ap_OnAreaPanelClicked(object sender, AreaPanelClickedArgs e)
    {
        OnAreaPanelClicked(this, e);
    }
}
