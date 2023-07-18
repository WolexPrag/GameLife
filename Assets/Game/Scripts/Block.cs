using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class Block : MonoBehaviour , IPointerClickHandler
{
    private GameObject block;
    public SpriteRenderer blockRednderer;
    public SpriteRenderer spriteLive;
    public SpriteRenderer spriteDead;
    public GeneratorWorld generator;
    public bool isLive;
    public void Start()
    {
        block = gameObject;
        blockRednderer = block.GetComponent<SpriteRenderer>();
        generator = block.GetComponentInParent<GeneratorWorld>();
    }
    public void Update()
    {
        Step();
    }
    public void FixedUpdate()
    {
        CheakSprite();
    }
    public void CheakSprite()
    { 
        if(isLive == true)
        {
            blockRednderer.color = spriteLive.color;
        }
        else
        {
            blockRednderer.color = spriteDead.color;
        }
    }
    public bool CheakLife(int neighborns,bool heIsLive)
    {
        Debug.Log(neighborns);
        if (heIsLive == true)
        {
            if (neighborns < 2)
            {
                return false;
            }
            else if (neighborns == 2 || neighborns == 3)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else if(heIsLive == false && neighborns == 3) {
            return true;
        }
        else
        {
            return false;
        }
    }
    public void Step()
    {
        isLive = CheakLife(neighborns:generator.GetNeighborn(block.transform.position),heIsLive:isLive);
        CheakSprite();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        isLive = !isLive;
    }
}
