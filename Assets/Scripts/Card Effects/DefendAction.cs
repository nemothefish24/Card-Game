using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace AK{
public class DefendAction : EffectAction
{   
    GameObject battleSystemScript;

    Unit affectedPlayerUnit;

    public DefendAction()
    {
        battleSystemScript = GameObject.Find("BattleSystem");
        affectedPlayerUnit = battleSystemScript.GetComponent<BattleSystem>().playerUnit;
    }
    public override void ApplyEffectAction(EffectActionData data)
    {
        affectedPlayerUnit.currentShield += data.tempEffectValue;
    }
}
}