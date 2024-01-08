using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


namespace Game.Menu.MVP.Standart 
{
    public abstract class View : MonoBehaviour
    {
        protected Presenter _presenter;
        public virtual void Init(Presenter presenter)
        {
            _presenter = presenter; 
        }
        public virtual void ClickNextFrame()
        {
            _presenter.NextFrame();
        }
        protected abstract void Paint();
        protected abstract void Display(Block showBlock);
        protected abstract void Display(List<Block> showBlock);
    } 
}
