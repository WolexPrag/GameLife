using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Game.Menu.MVP.Standart;

[System.Serializable]
public class View2d : View
{
    public Button NextFrameButton;
    public Button StopButton;
    protected IGetter<GameObject> _getter;
    [SerializeField] protected GameObject Prefab;
    private void Awake()
    {
        _getter = new Getter(Prefab);
    }
    private void OnEnable()
    {
        NextFrameButton.onClick.AddListener(ClickNextFrame);
    }
    private void OnDisable()
    {
        NextFrameButton.onClick.RemoveListener(ClickNextFrame);
    }
    protected override void Display(Block showBlock)
    {
        GameObject giveBlock = _getter.Take();
        giveBlock.SetActive(false);
        showBlock.Display(giveBlock);
        _getter.Return(giveBlock);
    }
    protected override void Display(List<Block> showBlock)
    {
        for (int i = 0; i < showBlock.Count; i++)
        {
            Display(showBlock[i]);
        }
    }
    public override void ClickNextFrame()
    {
        _presenter.NextFrame();
        Display(_presenter.GetDisplay());
    }
    protected override void Paint()
    {
        /*_presenter.SetBlock();*/
    }

}
