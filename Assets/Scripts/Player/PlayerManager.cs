using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour {

    [SerializeField] private PlayerModel model;
    [SerializeField] private PlayerView view;

    private static PlayerManager inst;
    public static PlayerManager Inst
    {
        get
        {
            return inst;
        } 
    }
    public PlayerManager()
    {
        inst = this;
    }


    public int limitNumOfPlayerOrc;


    // Use this for initialization
    void Start ()
    {
        limitNumOfPlayerOrc = 10;

        model.Init();
        view.Init();		
	}

    internal void ShowPlayerOrc()
    {
        view.ShowPlayerOrc(model);
    }
}
