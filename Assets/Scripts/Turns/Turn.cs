﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AK
{

[CreateAssetMenu(menuName = "Turns/Turn")]
public class Turn : ScriptableObject
{   
    public ActorHolder player;
    public string turnName; 
    [System.NonSerialized]
    public int index = 0;
    public PhaseVariable currentPhase; 
    
    public Phase[] phases;
    

    public bool Execute()
    {   
        bool result = false;
        currentPhase.value = phases[index];
        phases[index].OnStartPhase();
        

        bool phaseIsComplete = phases[index].IsComplete();

        if (phaseIsComplete)
        {   
            phases[index].OnEndPhase();

            index++;
            if(index > phases.Length - 1)
            {
                index = 0;
                result = true;
            }
            
        }

        return result;
    }

}
}