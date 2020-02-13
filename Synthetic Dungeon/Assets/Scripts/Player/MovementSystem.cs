using System.Collections;
using System.Collections.Generic;
using Core;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

public class MovementSystem : ComponentSystem
{
    protected override void OnUpdate()
    {
        float2 movementVector = GameManager.Instance.OnMoveVector;

        Entities.ForEach((ref Translation translation, ref Rotation rotation, ref PlayerTag playertag, ref MovementSpeedData movementSpeedData,
            ref RotationSpeedData rotationSpeedData) =>
        {

            rotation.Value = math.mul(math.normalize(rotation.Value), quaternion.AxisAngle(math.up(), movementVector.x * Time.DeltaTime * rotationSpeedData.Value));
            float3 foward = math.mul(rotation.Value, new float3(1,0,0));

            translation.Value += foward * movementSpeedData.Value * Time.DeltaTime * movementVector.y;
        });
        
    }
}
