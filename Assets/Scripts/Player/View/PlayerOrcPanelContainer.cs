using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOrcPanelContainer : MonoBehaviour {

    public List<PlayerOrcPanel> playerOrcPanelList;
    public Transform playerOrcPanelParent;

    internal void Init()
    {
        playerOrcPanelList = new List<PlayerOrcPanel>();

        GameObject prefab = Resources.Load("Player/PlayerOrcPanel") as GameObject;

        for(int i = 0; i < 20;i++)
        {
            PlayerOrcPanel pp = ((GameObject)Instantiate(prefab)).GetComponent<PlayerOrcPanel>();
            pp.transform.SetParent(playerOrcPanelParent);
            pp.Init();
            playerOrcPanelList.Add(pp);
        }
        Hide();
    }

    internal void Show(List<OrcData> orcList)
    {
        HidePlayerOrcPanelAll();

        int count = orcList.Count;

        for (int i = 0; i < count; i++)
        {
            OrcData data = orcList[i];
            PlayerOrcPanel pop = playerOrcPanelList[i];

            pop.Show(data);
        }

        this.gameObject.SetActive(true);
    }

    private void HidePlayerOrcPanelAll()
    {
        foreach (PlayerOrcPanel pop in playerOrcPanelList)
            pop.Hide();
    }
    public void Hide()
    {
        this.gameObject.SetActive(false);
    }
}
