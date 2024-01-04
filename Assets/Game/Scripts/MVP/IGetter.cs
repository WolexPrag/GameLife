using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGetter<T1> 
{
    public void Return(T1 value);
    public T1 Take();
}
