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

    public MenuView view;

    public bool isShowMenuPanel;
    
    void Start ()
    {
        InitView();
        isShowMenuPanel = true;		
	}

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isShowMenuPanel)
                HideMenuPanel();
            else
                ShowMenuPanel();

            isShowMenuPanel = !isShowMenuPanel;
        }
    }


    public void ShowMenuPanel()
    {
        view.ShowMenuPanel();
        isShowMenuPanel = true;
    }
    public void HideMenuPanel()
    {
        view.HideMenuPanel();
        isShowMenuPanel = false;
    }
    public void ChangeTitlePanel(string _name)
    {
        view.ChangeTitlePanel(_name);
    }
    
    private void InitView()
    {
        view.Init();
        view.OnMenuButtonClicked += _view_OnMenuButtonClicked;
        view.OnOpenIndicatorClicked += _view_OnOpenIndicatorClicked;
        ChangeTitlePanel(MenuNames.Main.ToString());
    }

    private void _view_OnOpenIndicatorClicked(object sender, EventArgs e)
    {
        ShowMenuPanel();
        view.HideOpenIndicator();
    }
    private void _view_OnMenuButtonClicked(object sender, MenuButtonClickedArgs e)
    {
        HideMenuPanel();
        view.ShowOpenIndicator();

        switch (e._clickedMenu)
        {
            case MenuNames.Main:
                break;
            case MenuNames.Talent:
                break;
            case MenuNames.Orc:
                PlayerManager.Inst.ShowPlayerOrc();
                break;
            case MenuNames.Item:
                break;
            case MenuNames.Area:
                AreaManager.Inst.ShowArea();
                break;
            case MenuNames.Store:
                break;
            default:
                break;
        }

    }
}
