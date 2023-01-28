using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class LineSpawnScheduler : MonoBehaviour
{
    [Header("Settings")]
    [Range(1, 7)]
    [SerializeField] private int _spawnDelaySeconds = 5;

    [Header("Components")]
    [SerializeField] private LineSpawner _spawner;

    private WaitForSeconds _spawnDelay;
    private bool _isNeetToSpawn;
    private Coroutine _spawnCorountine;

    private HashSet<LineDeactivator> _lines = new();    

    private void Awake()
    {
        _spawnDelay = new(_spawnDelaySeconds);
    }

    public void TryStartSpawning()
    {
        if (_spawnCorountine == null)        
            StartSpawning();        
    }

    public void TryStopSpawning()
    {
        if (_spawnCorountine != null)        
            StopSpawning();        
    }

    private void StartSpawning()
    {
        _isNeetToSpawn = true;
        _spawnCorountine = StartCoroutine(RepeatSpawning());
    }

    private void StopSpawning()
    {
        _isNeetToSpawn = false;
        StopAllCoroutines();
        _spawnCorountine = null;
    }

    private IEnumerator RepeatSpawning()
    {
        while (_isNeetToSpawn)
        {
            var line = _spawner.Spawn();

            _lines.Add(line);

            yield return _spawnDelay;
        }
    }

    public void DieactivateAllLines()
    {
        foreach (var line in _lines)
        {
            line.Deactivate();
        }
    }

}
