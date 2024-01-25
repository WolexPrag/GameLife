using Game.MVP;
using System.Collections;
using System.Collections.Generic;
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
            chekedBlock[i].IsLive = Rule(chekedBlock[i].IsLive, SortBlock(GetNeighborns(chekedBlock[i].pos), true).Count);
            nextFrame.Add(chekedBlock[i]);
        }

        _model.SetFloorBlock(nextFrame);
    }
    protected List<Block> GetBlocksForCheak()
    {
        List<Block> ret = _model.GetFloar();
        ret.Capacity = ret.Count * 9;
        List<Block> neighborns;
        int a = 0;
        for (int centers = 0; centers < ret.Count; centers++)
        {
            a++;
            neighborns = GetNeighborns(ret[centers].pos);
            for (int neigh = 0; neigh < neighborns.Count; neigh++)
            {
                a++;
                if (ret.Contains(neighborns[neigh]) == true)
                {
                    neighborns.RemoveAt(neigh);
                    neigh--;
                }
                if (a > 100)
                {
                    break;
                }
            }
            if (a > 100)
            {
                break;
            }
        }

        return ret;
    }

    protected override List<Block> SortBlock(List<Block> blocks, bool isLife)
    {
        return blocks.FindAll(f1 => f1.IsLive == isLife);
    }
}
