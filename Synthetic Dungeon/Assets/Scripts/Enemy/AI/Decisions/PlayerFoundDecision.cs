using System.Collections;
using System.Collections.Generic;
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
            return true;
        }
    }
}
