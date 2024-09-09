using System.Collections;
using UnityEngine;

namespace Jelewow.Arkanoid
{
    public interface ICoroutineRunner
    {
        Coroutine StartCoroutine(IEnumerator routine);
    }
}