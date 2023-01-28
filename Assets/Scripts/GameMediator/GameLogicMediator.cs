using UnityEngine;
using UnityEngine.Events;

public sealed class GameLogicMediator : MonoBehaviour
{
    [SerializeField] private LineSpawnScheduler _lineScheduler;
    [SerializeField] private BallSpawner _ballSpawner;

    public event UnityAction GameStopped;
    public event UnityAction GameStarted;

    private void OnEnable()
    {
        _ballSpawner.GameLoseDetectorSpawned += OnGameLoseDetectorSpawned;
    }

    private void OnDisable()
    {
        _ballSpawner.GameLoseDetectorSpawned -= OnGameLoseDetectorSpawned;
    }

    public void StartGame()
    {
        _ballSpawner.Spawn();

        _lineScheduler.TryStartSpawning();

        GameStarted?.Invoke();
    }

    public void StopGame()
    {
        _ballSpawner.DeactivateBall();

        _lineScheduler.TryStopSpawning();

        _lineScheduler.DieactivateAllLines();

        GameStopped?.Invoke();
    }

    private void OnGameLoseDetectorSpawned(GameLoseDetector detector)
    {
        detector.Detected += OnGameLoseDetected;
    }

    private void OnGameLoseDetected(GameLoseDetector detector)
    {
        detector.Detected -= OnGameLoseDetected;

        StopGame();
    }
}
