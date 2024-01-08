using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Menu.MVP.Standart;

[System.Serializable]
public class Model2d : Model
{
    protected List<Block> listGameObject;

    public Model2d(List<Block> blocks)
    {
        listGameObject = blocks;
    }

    public override Block GetBlock(Vector3 pos)
    {
        Block ret = listGameObject.Find(s1 => ((s1.pos.x == pos.x)&& (s1.pos.y == pos.y)&& (s1.pos.z == pos.z)));
        if (ret == null)
        {
            ret = new Block(pos, BlockState.NotLive);
        }
        return ret;
    }
    public override List<Block> GetLiveBlock()
    {
        return listGameObject;
    }
    public override List<Block> GetNeighborn(Vector3 pos)
    {
        List<Block> res = new List<Block>(8);
        for (float nx = pos.x - 1; nx <= pos.x + 1; nx++)
        {
            for (float ny = pos.y - 1; ny <= pos.y + 1; ny++)
            {
                res.Add(GetBlock(new Vector3(nx, ny,pos.z)));
            }
        }
        return res;
    }
    public override void SetLiveCube(List<Block> blocks)
    {
        listGameObject = blocks;
    }
    public override void SetLiveCube(Block block)
    {
        Block giveBlock = GetBlock(block.pos);
        if (giveBlock.state == BlockState.NotLive)
        {
            listGameObject.Add(block);
        }
        else
        {
            giveBlock = block;
        }
    }
}
