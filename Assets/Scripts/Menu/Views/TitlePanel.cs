using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitlePanel : MonoBehaviour {
    
    public Text _titleNameText;

    internal void Init()
    {

    }

    internal void ChangeTitle(string _name)
    {
        _titleNameText.text = _name;
    }

    
    
    
}
