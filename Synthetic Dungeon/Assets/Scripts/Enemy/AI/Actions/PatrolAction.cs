using System.Collections;
using System.Collections.Generic;
using Core;
using UnityEngine;

namespace Enemy.AI
{
    [CreateAssetMenu(menuName = "EnemyAI/Actions/Patrol")]
    public class PatrolAction : Action
    {
        public override void Act(StateController stateController)
        {
            Patrol(stateController);
        }
        
        private void Patrol(StateController stateController)
        {

            if (Vector3.Distance(stateController.transform.position, stateController.AgentTargetPoint) > 1.1f)
            {
                Vector3 targetVector = stateController.AgentTargetPoint - stateController.transform.position;
                
                Quaternion rotation = Quaternion.LookRotation(targetVector, Vector3.up);
                rotation.x = 0;
                rotation.z = 0;

                stateController.transform.rotation = Quaternion.Slerp(stateController.transform.rotation,  rotation,
                    Time.deltaTime * 10f);
                

                stateController.transform.position += stateController.AgentData.movementSpeed * Time.deltaTime *
                                                      targetVector.normalized;
            }
            else
            {
                Vector3 sp = stateController.AgentSpawnPoint;
                float offset = 10f;

                Vector3 newPos = new Vector3(Random.Range(sp.x - offset, sp.x + offset), sp.y,
                    Random.Range(sp.z - offset, sp.z + offset));
                
                stateController.AgentTargetPoint = newPos;
                GameManager.LogMessage("Patrol: new target position set");
            }
        }
    }
}