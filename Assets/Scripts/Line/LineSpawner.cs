using UnityEngine;

public sealed class LineSpawner : MonoBehaviour
{
    [Header("Prefab")]
    [SerializeField] private LineDeactivator _linePrefab;

    [Header("SpawnPoints")]
    [SerializeField] private Transform _spawnTopMaxPoint;
    [SerializeField] private Transform _spawnBottomMaxPoint;

    [Header("Difficulty")]
    [SerializeField] private DifficultySettings _difficultySettings;
    [SerializeField] private DifficultysSpeeds _spidsConfig;

    private Vector2 _topPosition;
    private Vector2 _bottomPosition;

    private ObjectPooler<LineDeactivator> _linePooler;

    private void Awake()
    {
        _topPosition = _spawnTopMaxPoint.position;
        _bottomPosition = _spawnBottomMaxPoint.position;

        _linePooler = new(Instantiate, _linePrefab);
    }

    public LineDeactivator Spawn()
    {
        LineDeactivator line = _linePooler.Get();
        SetStartPosition(line.gameObject);
        TrySetLineSpeed(line);

        return line;
    }

    private void TrySetLineSpeed(LineDeactivator line)
    {
        if (line.gameObject.TryGetComponent(out LineMovement lineMovement))        
            SetLineSpeed(lineMovement);        
    }

    private void SetStartPosition(GameObject line)
    {
        Vector2 spawnPoint = GetRandomSpawnPoint();
        line.SetActive(true);
        line.transform.position = spawnPoint;
    }

    private void SetLineSpeed(LineMovement line)
    {
        float speed = _spidsConfig.GetSpeedByDifficulty(_difficultySettings.CurrentDifficulty);
        line.Init(speed);
    }

    private Vector2 GetRandomSpawnPoint()
    {
        float randomLerpValue = Random.Range(0f, 1f);
        Vector2 lerpPositon = Vector2.Lerp(_topPosition, _bottomPosition, randomLerpValue);

        return lerpPositon;
    }
}
