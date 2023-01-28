using System.Collections;
using UnityEngine;

public sealed class CountdownSpeedIncrease : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private int _increaseDelaySeconds = 15;
    [SerializeField] private float _increaseScale = 1.5f;

    private BallMovement _movementToIncrease;
    private WaitForSeconds _increaseDelay;
    private bool _isNeetToIncrease;

    private void Awake() => _increaseDelay = new(_increaseDelaySeconds);

    public void Init(BallMovement ballMovement) => _movementToIncrease = ballMovement;

    public void StartCount()
    {
        _isNeetToIncrease = true;
        StartCoroutine(RepeatIncrease());
    }

    public void StopCount()
    {
        _isNeetToIncrease = false;
        StopAllCoroutines();
    }

    private IEnumerator RepeatIncrease()
    {
        yield return _increaseDelay;

        while (_isNeetToIncrease)
        {
            float currentSpeed = _movementToIncrease.VerticalMoveSpeed;

            float newSpeed = currentSpeed * _increaseScale;

            _movementToIncrease.SetVercticalSpeed(newSpeed);

            yield return _increaseDelay;
        }
    }
}
