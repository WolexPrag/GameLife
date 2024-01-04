using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Game.Menu.MVP.Standart
{
    public abstract class Presenter
    {
        protected View _view;
        protected Model _model;
        public Presenter(View view, Model model)
        {
            _view = view;
            _model= model;
        }
        public abstract void SetBlock(Vector3 pos);
        public abstract List<Block> GetCheakBlocks();
        public abstract List<Block> GetBlockForDisplay();
        public abstract int GetCountNeighborn(List<Block> blocks, BlockState state);
        public abstract BlockState Rule(BlockState centr,List<Block> neighborns);
        public abstract void NextFrame();
    }
}
