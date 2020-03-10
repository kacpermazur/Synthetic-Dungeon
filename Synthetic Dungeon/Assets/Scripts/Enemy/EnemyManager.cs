using System.Collections;
using System.Collections.Generic;
using Core;
using UnityEngine;

public class EnemyManager : MonoBehaviour, IInitializable, IOnExecute
{
    public bool Initialize()
    {
        GameManager.LogMessage("Enemy Manager Active");
        return true;
    }

    public void OnExecute()
    {
        
    }
}
