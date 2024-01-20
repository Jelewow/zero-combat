using System.Collections;
using UnityEngine;

namespace ZeroCombat.Bootstrapper
{
    public interface ICoroutineRunner
    {
        Coroutine StartCoroutine(IEnumerator enumerator);
    }
}