using System.Collections;
using System.Collections.Generic;
using Core;
using Enemy;
using UnityEngine;

public class DuengonManager : MonoBehaviour, IInitializable
{
    private EnemyManager _enemyManager;
    
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private Transform _backSpawn;
    [SerializeField] [Range(0, 12f)] private int _numberOfEnemies;
    [SerializeField] [Range(0, 2f)] private float _spawnPointRange;
    
    private int _duengonCurrentLevel;
    private int _spawnPointCount;
    private int _enemiesAlvie;
    
    public bool Initialize()
    {
        GameManager.LogMessage("DuengonManager Called!");

        _enemyManager = GameManager.Instance.EnemyManager;
        _duengonCurrentLevel = GameManager.Instance.PlayerManager.currentLevel;
        _spawnPointCount = _spawnPoints.Length;
        _enemiesAlvie = -1;

        return true;
    }

    public void StartDuengon()
    {
        GameManager.LogMessage("DuengonManager Duengon Started!");

        for (int i = 0; i < _numberOfEnemies; i++)
        {
            SpawnEnemies();
        }
        
    }
    
    public void StopDuengon()
    {
        GameManager.LogMessage("DuengonManager Duengon Stopped!");
        _enemyManager.ClearAllEnemies();
        GameManager.Instance.PlayerManager.transform.position = _backSpawn.position;
    }

    private void SpawnEnemies()
    {
        int spawnIndex = Random.Range(0, _spawnPointCount);
        Transform selectedSpawnPoint = _spawnPoints[spawnIndex];

        Vector3 pos = Vector3.zero;
        Vector3 spawnPointPos = selectedSpawnPoint.position;

        pos.x = Random.Range(spawnPointPos.x - _spawnPointRange, spawnPointPos.x + _spawnPointRange);
        pos.y = spawnPointPos.y;
        pos.z = Random.Range(spawnPointPos.z - _spawnPointRange, spawnPointPos.z + _spawnPointRange);
        
        _enemyManager.SpawnEnemy(pos, selectedSpawnPoint.rotation);
    }
}
