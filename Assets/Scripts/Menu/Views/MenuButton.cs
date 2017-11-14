using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public interface IMenuButton
{
    event EventHandler OnButtonClicked;
    MenuNames GetMenuName();
}

public class MenuButton : MonoBehaviour, IMenuButton {


    private MenuNames _menuNames;

    public Text _nameText;

    public event EventHandler OnButtonClicked;

    internal void Init(MenuNames _name)
    {
        _menuNames = _name;
        _nameText.text = _name.ToString();
    }

    public void MenuButtonClicked()
    {
        OnButtonClicked(this, EventArgs.Empty);
    }
    public MenuNames GetMenuName()
    {
        return _menuNames;
    }
}
