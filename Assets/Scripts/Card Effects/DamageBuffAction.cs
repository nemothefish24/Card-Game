using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace AK{
public class DamageBuffAction : EffectAction
{   
    GameObject battleSystemScript;

    Unit affectedPlayerUnit;

    public DamageBuffAction()
    {
        battleSystemScript = GameObject.Find("BattleSystem");
        affectedPlayerUnit = battleSystemScript.GetComponent<BattleSystem>().playerUnit;
    }

    public override void ApplyEffectAction(EffectActionData data)
    {
        affectedPlayerUnit.damage += data.effectValue;
    }
}
}