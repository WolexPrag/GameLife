using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.Events;

namespace Game.MVP
{
    public interface IView
    {
        event UnityAction nextFrame;
        event UnityAction<Vector3> paint;
        void Init();
        void UpdateFloar(List<Block> blocks);
    }
}