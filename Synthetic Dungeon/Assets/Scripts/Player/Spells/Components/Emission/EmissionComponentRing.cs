using System.Collections;
using System.Collections.Generic;
using Player.Spells.Components;
using UnityEngine;

public class EmissionComponentRing : EmissionComponent
{
    private const int NumPoints = 5;
    private const float RadiusX = 1f;
    private const float RadiusY = 1f;
    
    public override Vector3[] GetEmissionShape()
    {
        Vector3[] spellEmitters = new Vector3[NumPoints];

        Vector3 pos = transform.position;
        Vector3 centerPos = new Vector3(pos.x, 0.5f, pos.z);
            
        for(int i = 0; i < NumPoints; i++)
        {
            float pointNum = (i * 1.0f) / NumPoints;
            float angle = pointNum * Mathf.PI * 2;

            float x = Mathf.Sin(angle) * RadiusX;
            float y = Mathf.Cos(angle) * RadiusY;

            spellEmitters[i] = new Vector3(x, 0, y) + centerPos;
        }

        return spellEmitters;
    }
}
