using UnityEngine;
using UnityEngine.Events;

public sealed class GameLogicMediatorView : MonoBehaviour
{
    [SerializeField] private GameLogicMediator _gameLogic;

    [SerializeField] private UnityEvent OnStopGame;
    [SerializeField] private UnityEvent OnStartGame;

    private void OnEnable()
    {
        _gameLogic.GameStarted += OnGameStarted;
        _gameLogic.GameStopped += OnGameStopped;
    }

    private void OnDisable()
    {
        _gameLogic.GameStarted -= OnGameStarted;
        _gameLogic.GameStopped -= OnGameStopped;
    }

    private void OnGameStopped() => OnStopGame.Invoke();

    private void OnGameStarted() => OnStartGame.Invoke();
}
