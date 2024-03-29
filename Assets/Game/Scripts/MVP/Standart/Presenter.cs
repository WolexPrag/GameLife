using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.MVP
{
    [System.Serializable]
    public abstract class Presenter
    {
        protected IView _view;
        protected IModel _model;
        public void Init(IView view,IModel model)
        {
            _view = view;
            _model = model;
            _view.nextFrame += NextFrame;
            _view.paint += Paint;
            _model.FloorChanges += _view.UpdateFloar;

        }
        protected virtual void Paint(Vector3 pos)
        {
            Block set = _model.GetBlock(pos);
            set.IsLive = !set.IsLive;
            _model.SetBlock(set);
        }
        protected abstract void NextFrame();
        protected abstract List<Block> GetNeighborns(Vector3 pos); 
        protected abstract List<Block> SortBlock(List<Block> blocks,bool isLive);
        protected virtual bool Rule(bool center,int neighborns)
        {
            if (neighborns == 3)
            {
                return true;
            }
            if (center == true && neighborns == 2)
            {
                return true;
            }
            return false;
        }

    }
    
}
