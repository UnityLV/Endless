using TMPro;
using UnityEngine;

public sealed class AttempsCouter : MonoBehaviour
{
    private const string STARTED_GAMES_KEY = "GameStartedCounter";

    [SerializeField] private GameLogicMediator _gameLogic;
    [SerializeField] private TMP_Text _countText;

    private string _startTextPart = "Всего ";

    int _gameStartedCounter;

    private void OnEnable()
    {
        _gameLogic.GameStarted += OnGameStarted;
        _gameLogic.GameStopped += OnGameStopped;
    }

    private void Start()
    {
        TryLoadSaves();
    }  

    private void OnDisable()
    {
        _gameLogic.GameStarted -= OnGameStarted;
        _gameLogic.GameStopped -= OnGameStopped;
    }

    private void OnGameStarted() => _gameStartedCounter++;

    private void OnGameStopped()
    {
        _countText.text = _startTextPart + _gameStartedCounter.ToString();
        PlayerPrefs.SetInt(STARTED_GAMES_KEY, _gameStartedCounter);
        PlayerPrefs.Save();
    }

    private void TryLoadSaves()
    {
        if (PlayerPrefs.HasKey(STARTED_GAMES_KEY))
        {
            _gameStartedCounter = PlayerPrefs.GetInt(STARTED_GAMES_KEY);
        }
    }

}