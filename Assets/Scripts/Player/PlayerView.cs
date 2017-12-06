using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerView : MonoBehaviour {


    public PlayerOrcPanelContainer playerOrcPanelContainer;

	
    internal void Init()
    {
        playerOrcPanelContainer.Init();
    }

    internal void ShowPlayerOrc(PlayerModel model)
    {
        List<OrcData> orcList = model.PlayerOrcList;

        playerOrcPanelContainer.Show(orcList);
    }
}
