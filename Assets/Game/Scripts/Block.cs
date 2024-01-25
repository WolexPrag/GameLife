using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Block
{
    public Block(Vector3 pos, bool isLive )
    {
        _pos = pos;
        _IsLive = isLive;
    }
    [SerializeField] protected Vector3 _pos;
    [SerializeField] protected bool _IsLive;
    public Vector3 pos 
    {
        get { return _pos; } 
    }
    public bool IsLive 
    { 
        get { return _IsLive; } 
        set { _IsLive = value; } 
    }
}
