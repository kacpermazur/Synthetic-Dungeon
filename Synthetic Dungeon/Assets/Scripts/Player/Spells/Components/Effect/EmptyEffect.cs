using System.Collections;
using System.Collections.Generic;
using Core;
using UnityEngine;

namespace Player.Spells.Components
{
    public class EmptyEffect : EffectComponent
    {
        public override void Tick(Enemy.Enemy enemy)
        {
            GameManager.LogMessage("Nothing!!!!!!!!!!!!!");
        }
    }
}