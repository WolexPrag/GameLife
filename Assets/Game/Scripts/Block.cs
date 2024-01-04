using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Block
{
    [SerializeField] protected Vector3 _pos;
    public Vector3 pos { get { return _pos; } set { _pos = value; } }
    [SerializeField] protected BlockState _state;
    public BlockState state { get { return _state; } set { _state = value; } }
    public void Display(GameObject gameObject)
    {
        switch (state)
        {
            case (BlockState.NotLive):
                gameObject.SetActive(false);
                break;
            case (BlockState.Live):
                gameObject.transform.position = pos;
                gameObject.SetActive(true);
                break;
            default:
                decimal f = 1;
                decimal e = 0;
                decimal error = f / e;
                break;
        }
    }
    public Block(Vector3 pos,BlockState state)
    {
        this.pos = pos;
        this.state = state;
    }
}
