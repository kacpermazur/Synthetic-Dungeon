using System.Collections;
using System.Collections.Generic;
using Core;
using UnityEngine;

namespace Enemy.AI
{
    [CreateAssetMenu(menuName = "EnemyAI/Actions/Melee")]
    public class MeleeAction : Action
    {
        private float nextAttackTime = 0;
        
        public override void Act(StateController stateController)
        {
            Melee(stateController);
        }

        private void Melee(StateController stateController)
        {
            float eTime = Time.time;
            
            if (eTime > nextAttackTime)
            {
                GameManager.LogMessage("Melee Attack");
                nextAttackTime = eTime + stateController.AgentData.attackRate;
            }
        }
    }
}