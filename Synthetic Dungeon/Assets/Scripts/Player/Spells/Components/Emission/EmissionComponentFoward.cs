using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core;


namespace Player.Spells.Components
{
    public class EmissionComponentFoward : EmissionComponent
    {
        private const float Radius = 1f;

        public override Vector3[] GetEmissionShape(Vector3 origin)
        {
            Vector3[] spellEmitters = new Vector3[1];
            
            Vector3 pos = origin;
            Vector3 centerPos = new Vector3(pos.x, 0.5f, pos.z);

            float pointNum = (GameManager.Instance.PlayerManager.transform.rotation.eulerAngles.y+90 * 1.0f) / 360;

            float angle = pointNum * Mathf.PI * 2;

            float x = Mathf.Sin(angle) * Radius;
            float z = Mathf.Cos(angle) * Radius;

            spellEmitters[0] = new Vector3(x, 0, z) + centerPos;
            
            return spellEmitters;
        }
    }
}