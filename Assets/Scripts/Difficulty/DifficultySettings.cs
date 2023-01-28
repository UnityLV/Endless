using UnityEngine;
using UnityEngine.UI;

public sealed class DifficultySettings : MonoBehaviour
{
    [SerializeField] private Toggle _easyToggle;
    [SerializeField] private Toggle _normalToggle;
    [SerializeField] private Toggle _hardToggle;

    [SerializeField] private Difficulty _defaultDifficulty = Difficulty.Easy;

    private Toggle _lastOnTogle;

    private Difficulty _currentDifficulty;
    public Difficulty CurrentDifficulty => _currentDifficulty;

    private void Start()
    {
        _easyToggle.onValueChanged.AddListener(OnToggleValueChanged);
        _normalToggle.onValueChanged.AddListener(OnToggleValueChanged);
        _hardToggle.onValueChanged.AddListener(OnToggleValueChanged);

        SetDifficulty(_defaultDifficulty);
        _lastOnTogle = _normalToggle;
    }

    private void OnDestroy()
    {
        _easyToggle.onValueChanged.RemoveListener(OnToggleValueChanged);
        _normalToggle.onValueChanged.RemoveListener(OnToggleValueChanged);
        _hardToggle.onValueChanged.RemoveListener(OnToggleValueChanged);
    }

    private void OnToggleValueChanged(bool isOn)
    {
        var activeToggle = GetActiveToggle();

        bool isNoLeftEnebleToggle = activeToggle == null;

        if (isNoLeftEnebleToggle)
        {
            SetLastToggleOn();
            return;
        }

        _lastOnTogle = activeToggle;

        SetDifficultyBasedOnActiveToggle(activeToggle);
    }

    private void SetLastToggleOn() => _lastOnTogle.isOn = true;

    private void SetDifficultyBasedOnActiveToggle(Toggle activeToggle)
    {
        if (activeToggle == _easyToggle)
            SetDifficulty(Difficulty.Easy);
        else if (activeToggle == _normalToggle)
            SetDifficulty(Difficulty.Normal);
        else if (activeToggle == _hardToggle)
            SetDifficulty(Difficulty.Hard);
    }

    private Toggle GetActiveToggle()
    {
        if (_easyToggle.isOn)
            return _easyToggle;
        if (_normalToggle.isOn)
            return _normalToggle;
        if (_hardToggle.isOn)
            return _hardToggle;
        return null;
    }

    private void SetDifficulty(Difficulty difficulty) => _currentDifficulty = difficulty;
}
