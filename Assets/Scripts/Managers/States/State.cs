using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AK.GameStates
{

[CreateAssetMenu(menuName = "State")]
public class State : ScriptableObject
{
    public Action[] actions;
    public void Tick(float d) //uses a delta value passed in case needed for Time.deltaTime
    {
        for (int i = 0; i < actions.Length; i++)
        {
            actions[i].Execute(d);
        }
    }
}
}