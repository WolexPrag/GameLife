using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Menu.MVP.Standart;

[System.Serializable]
public class Presenter2d : Presenter
{
    public Presenter2d (View view , Model model) : base(view,model)
    {

    }
    public override List<Block> GetBlockForDisplay()
    {
        return _model.GetLiveBlock();   
    }

    public override int GetCountNeighborn(List<Block> blocks, BlockState state)
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

    public override List<Block> GetCheakBlocks()
    {
        List<Block> liveBlock = _model.GetLiveBlock();
        List<Block> ret = new List<Block>(liveBlock.Count * 9);
        List<Block> neighb;
        for (int i = 0; i < liveBlock.Count; i++)
        {
            neighb = _model.GetNeighborn(liveBlock[i].pos);
            for (int c = 0; c < neighb.Count; c++)
            {
                if (neighb[c].state == BlockState.NotLive)
                {
                    neighb.RemoveAt(c);
                    continue;
                }
                if (ret.Find(s1 => (s1.pos.x == neighb[c].pos.x) & (s1.pos.y == neighb[c].pos.y) & (s1.pos.z == neighb[c].pos.z)) != null)
                {
                    neighb.RemoveAt(c);
                    continue;
                }

            }
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

    public override void SetBlock(Vector3 pos)
    {
        BlockState states = _model.GetBlock(pos).state;
        if (states == BlockState.Live)
        {
            states = BlockState.NotLive;
        }
        else
        {
            states = BlockState.Live;
        }
        _model.SetLiveCube(new Block(pos,states));
    }
}
