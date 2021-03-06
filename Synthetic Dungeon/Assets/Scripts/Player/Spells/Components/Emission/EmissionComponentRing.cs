﻿using UnityEngine;
using Core;

namespace Player.Spells.Components
{
    [CreateAssetMenu(menuName = "Spells/Emission/Ring")]
    public class EmissionComponentRing : EmissionComponent
    {
        private const int NumPoints = 12;
        private const float RadiusX = 1f;
        private const float RadiusZ = 1f;
        public override Vector3[] GetEmissionShape(Vector3 origin)
        {
            Vector3[] spellEmitters = new Vector3[NumPoints];

            Vector3 pos = origin;
            Vector3 centerPos = new Vector3(pos.x, 0.5f, pos.z);

            for (int i = 0; i < NumPoints; i++)
            {
                float pointNum = (i * 1.0f) / NumPoints;
                float angle = pointNum * Mathf.PI * 2;

                float x = Mathf.Sin(angle) * RadiusX;
                float z = Mathf.Cos(angle) * RadiusZ;

                spellEmitters[i] = new Vector3(x, 0, z) + centerPos;
            }

            return spellEmitters;
        }
    }
}