using System.Collections;
using System.Collections.Generic;
using Core;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

/*
public class EnemySpawnSystem : ComponentSystem
{
    //private Entity _pfEnemyTemp;
    private Unity.Mathematics.Random _random;
    private float _timer;

    protected override void OnCreate()
    {
        _random = new Unity.Mathematics.Random(10);
    }

    protected override void OnUpdate()
    {
        _timer -= Time.DeltaTime;

        if (_timer <= 0f)
        {
            _timer = 0.5f;
            SpawnEnemy();
        }
    }

    private float3 SetRandomLocation()
    {
        float3 direction = new float3(_random.NextFloat(-1f, 1f), _random.NextFloat(-1f, 1f), 0f);
        return math.normalize(direction);
    }

    private void SpawnEnemy()
    {
        Entity entity = EntityManager.Instantiate(GameManager.PfEnemyTempEntity);
        EntityManager.SetComponentData(entity,
            new Translation {Value = SetRandomLocation() * _random.NextFloat(10f, 20f)});
    }
}

*/