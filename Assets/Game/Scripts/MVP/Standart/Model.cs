using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Game.Menu.MVP.Standart
{
    public abstract class Model
    {
        protected Presenter _presenter; 
        public void Init(Presenter presenter)
        {
            _presenter = presenter;
        }
        public abstract void SetLiveCube(List<Block> blocks);
        public abstract void SetLiveCube(Block block);
        public abstract List<Block> GetLiveBlock();
        public abstract Block GetBlock(Vector3 pos);
        public abstract List<Block> GetNeighborn(Vector3 pos);
    }
}
