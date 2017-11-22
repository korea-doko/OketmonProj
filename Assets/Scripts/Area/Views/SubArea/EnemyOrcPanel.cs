using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyOrcPanel : MonoBehaviour {

    public Text text;

    internal void Init()
    {

    }

    internal void Hide()
    {
        this.gameObject.SetActive(false);
    }

    internal void Show(OrcData data)
    {
        text.text = data.GetTestInfo();
        this.gameObject.SetActive(true);
    }
}
