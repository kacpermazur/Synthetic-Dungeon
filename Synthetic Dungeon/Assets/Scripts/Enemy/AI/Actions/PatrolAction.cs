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
            Debug.Log(Vector3.Distance(stateController.transform.position, stateController.AgentTargetPoint));

            if (Vector3.Distance(stateController.transform.position, stateController.AgentTargetPoint) > 1f)
            {
                Vector3 targetVector = stateController.AgentTargetPoint - stateController.transform.position;
                
                stateController.transform.rotation =
                    Quaternion.LookRotation(stateController.AgentTargetPoint, Vector3.up) * Quaternion.Euler(0, -90, 0);

                stateController.transform.position += stateController.AgentData.movementSpeed * Time.deltaTime *
                                                      targetVector;
            }
            else
            {
                Vector3 sp = stateController.AgentSpawnPoint;
                float offset = 10f;
                
                Vector3 newPos = new Vector3(Random.Range(sp.x - offset, sp.x + offset), sp.z,
                    Random.Range(sp.z - offset, sp.y + offset));
                
                stateController.AgentTargetPoint = newPos;
                GameManager.LogMessage("Patrol: new target position set");
            }
        }
    }
}