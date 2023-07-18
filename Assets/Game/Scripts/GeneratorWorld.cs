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
    private List<List<Block>> blockList;
    private void Awake()
    {
        blockList = new ();
    }
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
    public int GetNeighborn(Vector2 centrBlock)
    {
        int countNeighborn = 0;
        countNeighborn = countNeighborn + ((GetIsLiveAndCheakIndexs(new Vector2(centrBlock.x - 1, centrBlock.y - 1))) ? 1 : 0)
                                        + ((GetIsLiveAndCheakIndexs(new Vector2(centrBlock.x, centrBlock.y - 1))) ? 1 : 0)
                                        + ((GetIsLiveAndCheakIndexs(new Vector2(centrBlock.x + 1, centrBlock.y - 1))) ? 1 : 0)
                                        + ((GetIsLiveAndCheakIndexs(new Vector2(centrBlock.x - 1, centrBlock.y))) ? 1 : 0)
                                        + ((GetIsLiveAndCheakIndexs(new Vector2(centrBlock.x + 1, centrBlock.y))) ? 1 : 0)
                                        + ((GetIsLiveAndCheakIndexs(new Vector2(centrBlock.x - 1, centrBlock.y + 1))) ? 1 : 0)
                                        + ((GetIsLiveAndCheakIndexs(new Vector2(centrBlock.x, centrBlock.y + 1))) ? 1 : 0)
                                        + ((GetIsLiveAndCheakIndexs(new Vector2(centrBlock.x + 1, centrBlock.y + 1))) ? 1 : 0);
        return countNeighborn;
    }
    private bool GetIsLive(Vector2 indexs)
    {
        return blockList[(int)indexs.y][(int)indexs.x].isLive;
    }
    private Vector2 CheakIndexs(Vector2 indexs)
    {
        if (minPos.x > indexs.x)
        {
            indexs.x = indexs.x * -1;
        }
        if (maxPos.x < indexs.x)
        {
            indexs.x = indexs.x % (int)maxPos.x;
        }
        if (minPos.y > indexs.y)
        {
            indexs.y = indexs.y * -1;
        }
        if (maxPos.y < indexs.y)
        {
            indexs.y = indexs.y % (int)maxPos.y;
        }

        return indexs;
    }
    private bool GetIsLiveAndCheakIndexs(Vector2 indexs)
    {
        return GetIsLive(CheakIndexs(indexs));
    }
    public void StepAllBlock()
    {
        foreach (List<Block> blocks in blockList)
        {
            foreach (Block block in blocks)
            {
                block.Step();
            }
        }
    }
    private void GenerateWorld()
    {
        for (float y = minPos.y; y < maxPos.y; y++)
        {
            blockList.Add(new List<Block>());
            for (float x = minPos.x; x < maxPos.x; x++)
            {
                prefabObject.transform.SetPositon(x:x,y:y);
                blockList[(int)y].Add(Instantiate(prefabObject,parent.transform).GetComponent<Block>());
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
