using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy.AI
{
    [CreateAssetMenu(menuName = "EnemyAI/State")]
    public class State : ScriptableObject
    {
        public Action[] actions;
        public Transition[] transitions;

        public void UpdateState(StateController stateController)
        {
            ExecuteAction(stateController);
            CheckTransition(stateController);
        }

        public void ExecuteAction(StateController stateController)
        {
            foreach (var action in actions)
            {
                action.Act(stateController);
            }
        }

        private void CheckTransition(StateController stateController)
        {
            foreach (var transition in transitions)
            {
                bool conditionMet = transition.decision.Decide(stateController);
                
                stateController.ChangeState(conditionMet ? transition.trueState : transition.falseState);
            }
        }
    }
}