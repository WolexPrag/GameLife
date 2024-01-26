
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
    public event UnityAction<Vector3> paint;
    
    [SerializeField] protected Camera MainCamera;
    [Header("Buttons")]
    [SerializeField] protected Button nextFrameButton; 
    [Header("Grid")]
    [SerializeField] protected GameObject grid;
    [SerializeField] protected GameObject gridPart;
    [SerializeField] protected Vector3 gridSize;
    [SerializeField] protected Vector3 gridStartPos;
    [Header("View Block Property")]
    [SerializeField] protected GameObject Prefab;
    [SerializeField] protected List<GameObject> cluster;
    [Header("Other")]
    [SerializeField] protected GameObject viewPreviewPain;


    private void Awake()
    {
        CreateStartGrid();
    }
    private void Update()
    {
        viewPreviewPain.transform.position = RoundVector(mousePos);
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            paint.Invoke(RoundVector(mousePos));
        }
        MoveGrid();
    }
    public void CreateStartGrid()
    {
        Vector3 sizeCamera = MainCamera.sensorSize;
        print(sizeCamera);
    }
    public void MoveGrid()
    {
        grid.transform.position = PlusVector(
            gridStartPos, RoundVector(MainCamera.transform.position));
    }
    public GameObject CreateGrid(Vector3 pos)
    {
        return Instantiate(gridPart,grid.transform);
    }
    public Vector2 RoundVector(Vector2 vector)
    {
        return new Vector2(Mathf.Round(vector.x), Mathf.Round(vector.y));
    }
    public Vector3 PlusVector(Vector3 vector3,Vector2 vector2)
    {
        return new Vector3((vector3.x + vector2.x), (vector3.y + vector2.y), vector3.z);
    }
    public Vector2 mousePos
    {
        get { return MainCamera.ScreenToWorldPoint(Input.mousePosition); }
    }
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
