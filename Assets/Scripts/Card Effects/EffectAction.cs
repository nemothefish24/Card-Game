using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace AK{
public abstract class EffectAction 
{   
    public Unit playerUnit;
    public Unit enemyUnit;

    public EffectActionData effectData;
    
    public abstract void ApplyEffectAction(EffectActionData data);
}
}