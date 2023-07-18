using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorWorld : MonoBehaviour
{
    [Header("GameObject")]
    [SerializeField] private GameObject parent;
    [SerializeField] private GameObject prefabObject;
    [Space]
    [Header("Position")]
    [SerializeField] private Vector2 maxPos;
    [SerializeField] private Vector2 minPos;
    private void Start()
    {
        CheakSizeWorld();
        GenerateWorld();
    }
    private void CheakSizeWorld()
    {
        if (maxPos.x < minPos.x)
        {
            float minX = maxPos.x;
            maxPos.x = minPos.x;
            minPos.x = minX;
        }
        if (maxPos.y < minPos.y)
        {
            float minY = maxPos.y;
            maxPos.y = minPos.y;
            minPos.y = minY;
        }
    }
    private void GenerateWorld()
    {
        for (float y = minPos.y; y < maxPos.y; y++)
        {
            for (float x = minPos.x; x < maxPos.x; x++)
            {
                prefabObject.transform.SetPositon(x:x,y:y);
                Instantiate(prefabObject,parent.transform).GetComponent<Block>();
            }
            
        }
    }
    public void StopGame()
    {
        Time.timeScale = 0f;
    }
    public void PlayGame()
    {
        Time.timeScale = 1f;
    }
}
