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
            if (stateController.ETime > stateController.nextAttackTime)
            {
                GameManager.Instance.PlayerManager.TakeDamage(stateController.AgentData.damage);
                stateController.nextAttackTime = stateController.ETime + stateController.AgentData.attackRate;
            }
        }
    }
}