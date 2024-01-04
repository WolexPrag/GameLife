using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Menu.MVP.Standart;

public class MVPConector : MonoBehaviour
{
    [Header("Getter")]
    public Getter getter;
    public GameObject prefabBlockLive;
    [Space(10)]
    [Header("MVP")]
    public View2d view;
    public Model2d model;
    public Presenter2d presenter;
    [Space(10)]
    [Header("Other")]
    public List<Block> StartBlocks;
    public void Conect()
    {
        getter = new Getter(prefabBlockLive);
        view.Init(presenter,getter);
        model = new Model2d(presenter,StartBlocks);
        presenter = new Presenter2d(view, model);
    }
}
