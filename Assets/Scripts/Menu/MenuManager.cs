using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public enum MenuNames
{
    Main,
    Talent,
    Orc,
    Item,
    Area,
    Store,
}
public class MenuButtonClickedArgs : EventArgs
{
    public MenuNames _clickedMenu;

    public MenuButtonClickedArgs(MenuNames _name)
    {
        _clickedMenu = _name;
    }
    public MenuNames GetClickedName()
    {
        return _clickedMenu;
    }
}


public class MenuManager : MonoBehaviour {

    public MenuView _menuView;

    public bool _isShowMenuPanel;

    void Start ()
    {
        InitView();
        _isShowMenuPanel = true;		
	}

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (_isShowMenuPanel)
                HideMenuPanel();
            else
                ShowMenuPanel();

            _isShowMenuPanel = !_isShowMenuPanel;
        }
    }


    public void ShowMenuPanel()
    {
        _menuView.ShowMenuPanel();
        _isShowMenuPanel = true;
    }
    public void HideMenuPanel()
    {
        _menuView.HideMenuPanel();
        _isShowMenuPanel = false;
    }
    public void ChangeTitlePanel(string _name)
    {
        _menuView.ChangeTitlePanel(_name);
    }
    
    private void InitView()
    {
        _menuView.Init();
        _menuView.OnMenuButtonClicked += _menuView_OnMenuButtonClicked;

        ChangeTitlePanel(MenuNames.Main.ToString());
    }

    private void _menuView_OnMenuButtonClicked(object sender, MenuButtonClickedArgs e)
    {
        HideMenuPanel();
    }
}
