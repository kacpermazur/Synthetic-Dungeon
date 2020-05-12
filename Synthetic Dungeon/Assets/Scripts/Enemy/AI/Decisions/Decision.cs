﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy.AI
{
    public abstract class Decision : ScriptableObject
    {
        public abstract bool Decide(StateController stateController);
    }
}