using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Game.Menu.MVP.Standart
{
    public abstract class Presenter
    {
        protected View _view;
        protected Model _model;
        public void Init(View view, Model model)
        {
            _view = view;
            _model= model;
        }
        public abstract BlockState Rule(BlockState centr,List<Block> neighborns);
        public abstract void NextFrame();
        public abstract List<Block> GetDisplay();
    }
}

