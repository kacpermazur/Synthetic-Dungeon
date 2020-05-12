using System.Collections;
using System.Collections.Generic;
using Core;
using UnityEngine;

namespace Enemy.AI
{
    public class AggresivePursuit : Action
    {
        public override void Act(StateController stateController)
        {
            Aggresive(stateController);
        }

        private void Aggresive(StateController stateController)
        {
            GameManager.LogMessage("Aggresive");
            
            Vector3 targetVector = GameManager.Instance.PlayerManager.Transform.position -
                                   stateController.transform.position;

            Quaternion rotation = Quaternion.LookRotation(targetVector, Vector3.up) * Quaternion.Euler(0, -90, 0);
            rotation.x = 0;
            rotation.z = 0;

            stateController.transform.rotation = Quaternion.Slerp(stateController.transform.rotation, rotation,
                Time.deltaTime * 10f);


            stateController.transform.position += (stateController.AgentData.movementSpeed + 1.5f) * Time.deltaTime *
                                                  targetVector.normalized;
        }
    }
}