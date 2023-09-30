using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace AK{
public class DefendAction : EffectAction
{   
    GameObject battleSystemScript;

    Unit affectedPlayerUnit;

    EffectActionData defendCardData;

    public DefendAction(CardInstance passedDefendCard)
    {
        battleSystemScript = GameObject.Find("BattleSystem");
        affectedPlayerUnit = battleSystemScript.GetComponent<BattleSystem>().playerUnit;
        defendCardData = passedDefendCard.viz.card.effect.cardEffectActionData;
    }
    public override void ApplyEffectAction(EffectActionData data)
    {
        affectedPlayerUnit.currentShield += data.tempEffectValue;
    }
}
}