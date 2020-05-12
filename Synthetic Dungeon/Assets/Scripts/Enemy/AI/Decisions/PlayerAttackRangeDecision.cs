﻿using System.Collections;
using System.Collections.Generic;
using Core;
using UnityEngine;

namespace Enemy.AI
{
    public class PlayerAttackRangeDecision : Decision
    {
        public override bool Decide(StateController stateController)
        {
            return PlayerWithinAttackRange(stateController);
        }

        private bool PlayerWithinAttackRange(StateController stateController)
        {
            if (Vector3.Distance(stateController.transform.position, GameManager.Instance.PlayerManager.Transform.position) < stateController.AgentData.attackRange)
            {
                return true;
            }
            return false;
        }
    }
}