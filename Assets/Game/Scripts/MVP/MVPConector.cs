using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Menu.MVP.Standart;

public class MVPConector : MonoBehaviour
{
    [Space(10)]
    [Header("MVP")]
    public View view;
    public Model model;
    public Presenter presenter;
    [Space(10)]
    [Header("Other")]
    public List<Block> StartBlocks;
    public void Conect()
    {
        model = new Model2d(StartBlocks);
        presenter = new Presenter2d();
        model.Init(presenter);
        presenter.Init(view, model);
        view.Init(presenter);
    }
    [ContextMenu("Test/PrintGetLiveBlock")]
    public void PrintGetLiveBlock()
    {
        List<Block> blocks = new List<Block>();
        blocks.AddRange(model.GetLiveBlock());
        for (int i = 0; i < blocks.Count; i++)
        {
            print($"Block ({blocks[i].pos}) = {blocks[i].state}");
        }
    }
    [ContextMenu("Test/PrintGetDisplay")]
    public void PrintGetDisplay()
    {
        List<Block> blocks = new List<Block>();
        blocks.AddRange(presenter.GetDisplay());
        for (int i = 0; i < blocks.Count; i++)
        {
            print($"Block ({blocks[i].pos}) = {blocks[i].state}");
        }
    }
}
