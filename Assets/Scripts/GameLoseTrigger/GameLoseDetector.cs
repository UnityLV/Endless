using UnityEngine;
using UnityEngine.Events;

public sealed class GameLoseDetector : MonoBehaviour
{
    public event UnityAction<GameLoseDetector> Detected;

    public void Detect() => Detected?.Invoke(this);

}
