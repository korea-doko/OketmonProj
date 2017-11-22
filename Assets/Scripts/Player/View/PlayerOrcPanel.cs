using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerOrcPanel : MonoBehaviour {

    public Text text;


    internal void Init()
    {

    }
    internal void Show(OrcData data)
    {
        text.text = data.GetTestInfo();
        this.gameObject.SetActive(true);
    }

    internal void Hide()
    {
        this.gameObject.SetActive(false);
    }
}
