using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Menu.MVP.Standart;

[System.Serializable]
public class View2d : View
{
    public override void Display(Block showBlock)
    {
        GameObject giveBlock = _getter.Take();
        giveBlock.SetActive(false);
        showBlock.Display(giveBlock);
        _getter.Return(giveBlock);
    }

    public override void Display(List<Block> showBlock)
    {
        for (int i = 0; i < showBlock.Count; i++)
        {
            Display(showBlock[i]);
        }
    }

    public override void Init(Presenter presenter,IGetter<GameObject> getter)
    {
        base.Init(presenter,getter);
    }
    public override void NextFrame()
    {
        _presenter.NextFrame();
        Display(_presenter.GetBlockForDisplay());
    }
    public override void Paint()
    {
        /*_presenter.SetBlock();*/
    }

}
