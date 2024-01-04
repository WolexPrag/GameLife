using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


namespace Game.Menu.MVP.Standart 
{
    public abstract class View : MonoBehaviour
    {
        public IGetter<GameObject> _getter;
        public Presenter _presenter;
        public virtual void Init(Presenter presenter,IGetter<GameObject> getter)
        {
            _presenter = presenter;
            _getter = getter;
        }
        public virtual void NextFrame()
        {
            _presenter.NextFrame();
        }
        public abstract void Paint();
        public abstract void Display(Block showBlock);
        public abstract void Display(List<Block> showBlock);
    } 
}
