using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Menu.MVP.Standart;

[System.Serializable]
public class Presenter2d : Presenter
{
    public override List<Block> GetDisplay()
    {
        return _model.GetLiveBlock();   
    }

    public int GetCountNeighborn(List<Block> blocks, BlockState state)
    {
        int res = 0;
        for (int i = 0; i < blocks.Count; i++)
        {
            if (blocks[i].state == state)
            {
                res++;
            }
        }
        return res;
    }

    public List<Block> GetCheakBlocks()
    {
        List<Block> liveBlock = _model.GetLiveBlock();
        List<Block> ret = new List<Block>(liveBlock.Count * 9);
        List<Block> neighb;
        for (int i = 0; i < liveBlock.Count; i++)
        {
            neighb = _model.GetNeighborn(liveBlock[i].pos);
            for (int c = 0; c < neighb.Count; c++)
            {
                if (ret.Find(s1 => (s1.pos.x == neighb[c].pos.x) & (s1.pos.y == neighb[c].pos.y) & (s1.pos.z == neighb[c].pos.z)) != null)
                {
                    neighb.Remove(neighb[c]);
                    continue;
                }
            }
            ret.AddRange(neighb);
        }
        return ret;
    }
    public override void NextFrame()
    {
        List<Block> current = GetCheakBlocks();
        List<Block> next = new List<Block>(current.Count);
        for (int i = 0; i < current.Count; i++)
        {
            if (Rule(current[i].state,_model.GetNeighborn(current[i].pos))==BlockState.NotLive)
            {
                continue;
            }
            next.Add(current[i]);
        }
        _model.SetLiveCube(next);
    }

    public override BlockState Rule(BlockState centr, List<Block> neighborns)
    {
        int countLiveNeighborns = GetCountNeighborn(neighborns, BlockState.Live);
        if (countLiveNeighborns == 3 && centr == BlockState.NotLive) 
        {
            return BlockState.Live;
        }
        else if (countLiveNeighborns == 2 && centr == BlockState.Live)
        {
            return BlockState.Live;
        }
        else
        {
            return BlockState.NotLive;
        }
        
    }
}
