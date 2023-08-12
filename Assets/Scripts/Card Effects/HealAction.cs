using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace AK{
public class HealAction : EffectAction
{
    GameObject battleSystemScript;

    Unit affectedPlayerUnit;

    public HealAction()
    {
        battleSystemScript = GameObject.Find("BattleSystem");
        affectedPlayerUnit = battleSystemScript.GetComponent<BattleSystem>().playerUnit;
    }
    public override void ApplyEffectAction(EffectActionData data)
    {
        affectedPlayerUnit.currentHP += data.effectValue;
    }
}
}