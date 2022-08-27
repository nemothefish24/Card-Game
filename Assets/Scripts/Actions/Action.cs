using System.Collections;
using UnityEngine;

namespace AK.GameStates
{
public abstract class Action : ScriptableObject
{
    public abstract void Execute(float d);
}
}
