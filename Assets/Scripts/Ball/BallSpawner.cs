using UnityEngine;
using UnityEngine.Events;

public sealed class BallSpawner : MonoBehaviour
{
    [Header("Settings")]   
    [SerializeField] private Transform _spawnPoint;

    [Header("Components")]
    [SerializeField] private HoldableButton _ballMoveButton;
    [SerializeField] private BallMovement _ballPrefab;
    [SerializeField] private CountdownSpeedIncrease _ballSpeedIncreases;

    private BallMovement _ball;

    public event UnityAction<GameLoseDetector> GameLoseDetectorSpawned;

    public void Spawn()
    {
        if (_ball == null)
            CreateBall();
        else
            ActivateBall();

        TryInvokeGameLoseDetector();
    }

    private void CreateBall()
    {
        _ball = Instantiate(_ballPrefab, _spawnPoint.position, _spawnPoint.rotation);

        _ball.Init(_ballMoveButton);
        _ballSpeedIncreases.Init(_ball);

        _ballSpeedIncreases.StartCount();
    }

    public void DeactivateBall()
    {
        _ball.gameObject.SetActive(false);
        _ballSpeedIncreases.StopCount();
    }

    private void ActivateBall()
    {
        _ball.gameObject.SetActive(true);
        _ball.transform.position = _spawnPoint.position;        
        _ballSpeedIncreases.StartCount();
    }

    private void TryInvokeGameLoseDetector()
    {
        if (_ball.gameObject.TryGetComponent(out GameLoseDetector detector))
        {
            GameLoseDetectorSpawned?.Invoke(detector);
        }
    }
}
