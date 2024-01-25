using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Game.MVP
{
    public interface IModel
    {
        event UnityAction<List<Block>> FloorChanges;
        void Init();
        void SetFloorBlock(List<Block> blocks);
        void SetBlock(Block block);
        List<Block> GetFloar();
        Block GetBlock(Vector3 pos);
    }
}
