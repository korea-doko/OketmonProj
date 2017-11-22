using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public interface IMenuView
{
    event EventHandler<MenuButtonClickedArgs> OnMenuButtonClicked;
    event EventHandler OnOpenIndicatorClicked;
}
public class MenuView : MonoBehaviour,IMenuView {

    public MenuPanel _menuPanel;
    public TitlePanel _titlePanel;
    public OpenIndicatorPanel _openIndicatorPanel;


    public event EventHandler<MenuButtonClickedArgs> OnMenuButtonClicked;
    public event EventHandler OnOpenIndicatorClicked;

    internal void Init()
    {
        InitMenuPanel();

        _titlePanel.Init();

        _openIndicatorPanel.Init();
        _openIndicatorPanel.OnOpenIndicatorClicked += _openIndicatorPanel_OnOpenIndicatorClicked;
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
    internal void ShowOpenIndicator()
    {
        _openIndicatorPanel.Show();
    }
    internal void HideOpenIndicator()
    {
        _openIndicatorPanel.Hide();
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
    private void _openIndicatorPanel_OnOpenIndicatorClicked(object sender, EventArgs e)
    {
        OnOpenIndicatorClicked(this, e);
    }

    
}
