using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace AK{
public abstract class DamageAction : EffectAction
{
    public override void ApplyEffectAction(EffectActionData data)
    {
        enemyUnit.currentHP -= data.effectValue;
    }
}
}