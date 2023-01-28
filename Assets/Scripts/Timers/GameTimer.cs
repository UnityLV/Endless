using TMPro;
using UnityEngine;

public sealed class GameTimer : MonoBehaviour
{
    [SerializeField] private TMP_Text _timerText;
    [SerializeField] private GameLogicMediator _gameLogic;

    private float _startTime;
    private float _elapsedTime;

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

    private void OnGameStarted() => _startTime = Time.realtimeSinceStartup;

    private void OnGameStopped()
    {
        CalsulateTime(out int milliSeconds, out int seconds, out int minues);
        string timeText = CalculateTimeText(milliSeconds, seconds, minues);
        SetText(timeText);
    }

    private void CalsulateTime(out int milliSeconds, out int seconds, out int minutes)
    {
        _elapsedTime = Time.realtimeSinceStartup - _startTime;
        minutes = (int)_elapsedTime / 60;
        seconds = (int)_elapsedTime % 60;
        milliSeconds = (int)((_elapsedTime - minutes * 60 - seconds) * 1000);
    }

    private string CalculateTimeText(int milliSeconds, int seconds, int minutes)
    {
        string text =  seconds.ToString("00") + ":" + milliSeconds.ToString("000");

        bool isNeetToShowMinutes = minutes > 0;
        if (isNeetToShowMinutes)        
            text = minutes.ToString("00") + ":" + text;

        return text;       
    }

    private void SetText(string text) => _timerText.text = text;
}
