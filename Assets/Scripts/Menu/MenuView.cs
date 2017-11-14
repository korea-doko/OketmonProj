using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public interface IMenuView
{
    event EventHandler<MenuButtonClickedArgs> OnMenuButtonClicked;
}
public class MenuView : MonoBehaviour,IMenuView {

    public MenuPanel _menuPanel;
    public TitlePanel _titlePanel;
    public OpenIndicatorPanel _openIndicatorPanel;


    public event EventHandler<MenuButtonClickedArgs> OnMenuButtonClicked;

    internal void Init()
    {
        InitMenuPanel();

        _titlePanel.Init();

        _openIndicatorPanel.Init();
    }

    internal void ShowMenuPanel()
    {
        _menuPanel.Show();       
    }
    internal void HideMenuPanel()
    {
        _menuPanel.Hide();      
    }
    internal void ChangeTitlePanel(string name)
    {
        _titlePanel.ChangeTitle(name);
    }
    private void InitMenuPanel()
    {
        _menuPanel.Init();
        _menuPanel.OnMenuButtonClicked += _menuPanel_OnMenuButtonClicked;
    }

    private void _menuPanel_OnMenuButtonClicked(object sender, MenuButtonClickedArgs e)
    {
        OnMenuButtonClicked(this, e);
    }

    
}
