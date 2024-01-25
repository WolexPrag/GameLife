using System.Collections.Generic;
using UnityEngine;
using Game.MVP;
using UnityEngine.Events;

public class Model2D : MonoBehaviour, IModel
{
    [SerializeField] protected List<Block> floar;
    [SerializeField] public event UnityAction<List<Block>> FloorChanges;

    protected Block FindBlock(Vector3 pos)
    {
        return floar.Find(f1 => (f1.pos.x == pos.x) && (f1.pos.y == pos.y) && (f1.pos.z == pos.z));
    }
    public void Init()
    {
        if (floar == null)
        {
            floar = new List<Block>(25);
        }
    }
    public Block GetBlock(Vector3 pos)
    {
        Block ret = FindBlock(pos);
        if (ret == null)
        {
            ret = new Block(pos, false);
            floar.Add(ret);
        }

        return ret;
    }

    public List<Block> GetFloar()
    {
        return floar;
    }
    public void SetBlock(Block block)
    {
        Block where = FindBlock(block.pos);
        FloorChanges?.Invoke(floar);
    }

    public void SetFloorBlock(List<Block> blocks)
    {
        floar = blocks;
        FloorChanges?.Invoke(floar);
    }
}
