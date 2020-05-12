using System.Collections;
using System.Collections.Generic;
using Core;
using UnityEngine;

namespace Enemy.AI
{
    [CreateAssetMenu(menuName = "EnemyAI/Decisions/PlayerFound")]
    public class PlayerFoundDecision : Decision
    {
        public override bool Decide(StateController stateController)
        {
            return PlayerDetected(stateController);
        }

        private bool PlayerDetected(StateController stateController)
        {
            if (Vector3.Distance(stateController.transform.position, GameManager.Instance.PlayerManager.Transform.position) < stateController.AgentData.distanceToPlayerDetection)
            {
                return true;
            }
            return false;
        }
    }
}
