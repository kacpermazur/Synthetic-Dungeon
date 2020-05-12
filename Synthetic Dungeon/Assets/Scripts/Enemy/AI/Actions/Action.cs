using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy.AI
{
    public abstract class Action : ScriptableObject
    {
        public abstract void Act(StateController stateController);
    }
}