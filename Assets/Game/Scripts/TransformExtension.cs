using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class TransformExtension
{
    public static void RoundPosition(this Transform transform)
    {
        transform.position = new Vector3(Mathf.Round(transform.position.x), Mathf.Round(transform.position.y), Mathf.Round(transform.position.z));
    } 
    public static void SetPositon(this Transform transform,float? x = null, float? y = null, float? z = null)
    {
        transform.position = new Vector3(x:(x ?? transform.position.x),y: (y ?? transform.position.y),z: (z ?? transform.position.z));
    }
}
