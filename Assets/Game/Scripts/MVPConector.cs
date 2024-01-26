using Game.MVP;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;


public class MVPConector : MonoBehaviour
{
    [SerializeField] protected Button connectButton;
    [SerializeField] protected View2D view;
    [SerializeField] protected Model2D model;
    protected Presenter2D presenter;
    private void Awake()
    {
        Conect();
    }
    public void Conect()
    {
        presenter = new Presenter2D();
        view.Init();
        model.Init();
        presenter.Init(view,model);
    }
    [ContextMenu("Display Floar")]
    public void Display()
    {
        view.UpdateFloar(model.GetFloar().FindAll(f1 => f1.IsLive == true));
    }
  
}


