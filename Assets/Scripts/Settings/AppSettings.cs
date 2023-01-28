using UnityEngine;

public sealed class AppSettings : MonoBehaviour
{
    private int _targetFPS = 60;

    private void Awake()
    {
        Application.targetFrameRate = _targetFPS;
    }

}
