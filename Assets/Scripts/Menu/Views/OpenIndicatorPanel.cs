using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class OpenIndicatorPanel : MonoBehaviour {

    public Animator _animator;
    private bool _isShow;
    public event EventHandler OnOpenIndicatorClicked;
    internal void Init()
    {
        Hide();
    }

    public void Show()
    {
        _isShow = true;
        _animator.SetBool("IsShow", _isShow);
    }
    public void Hide()
    {
        _isShow = false;
        _animator.SetBool("IsShow", _isShow);
    }

    public void Clicked()
    {
        OnOpenIndicatorClicked(this, EventArgs.Empty);
    }
}
