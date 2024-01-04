using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Getter : IGetter<GameObject>
{
    [SerializeField]
    protected List<GameObject> _storage;
    [SerializeField]
    protected GameObject _prefab;
    public Getter(GameObject prefab)
    {
        this._storage = new List<GameObject>(10);
        this._prefab = prefab;
    }
    protected void Create()
    {
        _storage.Add(GameObject.Instantiate(_prefab));
    }
    public void Return(GameObject value)
    {
        _storage.Add(value);
    }
    public GameObject Take()
    {
        if (_storage.Count < 1)
        {
            Create();
        }
        GameObject ret = _storage[_storage.Count - 1];
        _storage.RemoveAt(_storage.Count - 1);
        return ret;
    }
}
