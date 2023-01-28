using UnityEngine.Events;

public interface IPooleable
{
    event UnityAction<IPooleable> Deactivation;

    public void Deactivate();
}
