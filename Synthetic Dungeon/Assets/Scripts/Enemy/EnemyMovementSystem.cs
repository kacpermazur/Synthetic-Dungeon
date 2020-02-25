using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

public class EnemyMovementSystem : ComponentSystem
{
    protected override void OnUpdate()
    {
        Entities.WithAll<EnemyTag>().ForEach((ref Translation translation, ref MovementSpeedData movementSpeedData) =>
        {
            float3 playerPosition = float3.zero;
            
            Entities.WithAll<PlayerTag>().ForEach((ref Translation playerTranslation) =>
            {
                playerPosition = playerTranslation.Value;
            });

            float3 movementDirection = math.normalize(playerPosition - translation.Value);
            translation.Value += movementDirection * movementSpeedData.Value * Time.DeltaTime;

        });
    }
}
