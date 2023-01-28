using UnityEngine;
using UnityEngine.Events;

public sealed class LineDeactivator : MonoBehaviour, IPooleable
{
    public event UnityAction<IPooleable> Deactivation;

    public void Deactivate()
    {
        gameObject.SetActive(false);
        Deactivation?.Invoke(this);
    }
}
