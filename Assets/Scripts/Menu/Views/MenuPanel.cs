using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public interface IMenuPanel
{
    event EventHandler<MenuButtonClickedArgs> OnMenuButtonClicked;
}

public class MenuPanel : MonoBehaviour,IMenuPanel {

    public Animator _animator;
    public List<MenuButton> _menuBtnList;    

    private bool _isShow;

    public event EventHandler<MenuButtonClickedArgs> OnMenuButtonClicked;

    internal void Init()
    {
        InitMenuButton();
        Show();
    }

    internal void Show()
    {
        _isShow = true;
        _animator.SetBool("IsShow", _isShow);
    }
    internal void Hide()
    {
        _isShow = false;
        _animator.SetBool("IsShow", _isShow);
    }

    private void InitMenuButton()
    {
        _menuBtnList = new List<MenuButton>();

        GameObject prefab = Resources.Load("Menu/MenuButton") as GameObject;

        int numOfMenu = System.Enum.GetNames(typeof(MenuNames)).Length;

        for(int i = 0; i < numOfMenu;i++)
        {
            MenuButton btn = ((GameObject)Instantiate(prefab)).GetComponent<MenuButton>();
            btn.Init((MenuNames)i);
            btn.transform.SetParent(this.transform);
            btn.OnButtonClicked += Btn_OnButtonClicked;
            _menuBtnList.Add(btn);
        }
    }

    private void Btn_OnButtonClicked(object sender, EventArgs e)
    {
        IMenuButton btn = (IMenuButton)sender;
        OnMenuButtonClicked(this, new MenuButtonClickedArgs(btn.GetMenuName()));        
    }
}
