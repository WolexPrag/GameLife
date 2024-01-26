using Game.MVP;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Presenter2D : Presenter
{
    protected override List<Block> GetNeighborns(Vector3 pos)
    {
        List<Block> ret = new List<Block>(8);
        for (float xn = pos.x - 1; xn <= pos.x + 1; xn++)
        {
            for (float yn = pos.y - 1; yn <= pos.y + 1; yn++)
            {
                if (xn == pos.x && yn == pos.y)
                {
                    continue;
                }
                ret.Add(_model.GetBlock(new Vector3(xn,yn,pos.z)));
            }
        }
        return ret;
    }

    protected override void NextFrame()
    {
        List<Block> chekedBlock = GetBlocksForCheak();
        List<Block> nextFrame = new List<Block>(chekedBlock.Count);
        for (int i = 0; i < chekedBlock.Count; i++)
        {
            nextFrame.Add(new Block(
                chekedBlock[i].pos, 
                Rule(chekedBlock[i].IsLive,SortBlock(GetNeighborns(chekedBlock[i].pos), true).Count))
                );
        }

        _model.SetFloorBlock(nextFrame);
    }
    protected List<Block> GetBlocksForCheak()
    {
        List<Block> curentBlocks = SortBlock(_model.GetFloar(),true);
        List<Block> ret = new List<Block>(curentBlocks.Count * 9);
        for (int i = 0; i < curentBlocks.Count; i++)
        {
            ret.Add(curentBlocks[i]);
            ret.AddRange(GetNeighborns(curentBlocks[i].pos));
        }
        ret = ret.GroupBy(x => x.pos).Select(x => x.First()).ToList();
        return ret;
    }
    protected override void Paint(Vector3 pos)
    {
        Block set = _model.GetBlock(
                 new Vector3(Mathf.Round(pos.x), Mathf.Round(pos.y), Mathf.Round(pos.z))
                 );
        set.IsLive = !set.IsLive;
        _model.SetBlock(set);
    }
    protected override List<Block> SortBlock(List<Block> blocks, bool isLife)
    {
        return blocks.FindAll(f1 => f1.IsLive == isLife);
    }
}
