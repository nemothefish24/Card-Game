using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace AK{
public abstract class BuffAction : EffectAction
{
    public override void ApplyEffectAction(EffectActionData data)
    {
        playerUnit.damage += data.effectValue;
    }
}
}