
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.MVP;
using UnityEngine.Events;
using static Unity.Collections.AllocatorManager;
using UnityEngine.UI;

[System.Serializable]
public class View2D : MonoBehaviour, IView
{
    public event UnityAction nextFrame;
    [SerializeField] protected Button nextFrameButton;
    [SerializeField] protected GameObject Prefab;
    [SerializeField] protected List<GameObject> cluster;

    public void Init()
    {
        if (cluster == null) 
        {
            cluster = new List<GameObject>();
        }

        nextFrameButton.onClick.AddListener(() => 
        { nextFrame?.Invoke(); }) ;
    }
    public void UpdateFloar(List<Block> blocks)
    {
        if (cluster.Count < blocks.Count)
        {
            ClusterExpansion(blocks.Count);
        }
        for (int i  = 0; i < cluster.Count; i++)
        {
            if (i < blocks.Count)
            {
                cluster[i].SetActive(true);
                cluster[i].transform.position = blocks[i].pos;
            }
            else
            {
                cluster[i].SetActive(false);
            }
        }

    }
    protected void ClusterExpansion(int needSize)
    {
        for (int i = cluster.Count; i < needSize; i++)
        {
            cluster.Add(Instantiate(Prefab));
        }
    }

    
}
