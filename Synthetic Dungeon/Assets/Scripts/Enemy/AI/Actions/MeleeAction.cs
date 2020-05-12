using System.Collections;
using System.Collections.Generic;
using Core;
using UnityEngine;

namespace Enemy.AI
{
    [CreateAssetMenu(menuName = "EnemyAI/Actions/Melee")]
    public class MeleeAction : Action
    {
        public override void Act(StateController stateController)
        {
            Melee(stateController);
        }

        private void Melee(StateController stateController)
        {
            GameManager.LogMessage("Melee Attack");
        }
    }
}