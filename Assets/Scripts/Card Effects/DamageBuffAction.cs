using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace AK{
public class DamageBuffAction : EffectAction
{   
    GameObject battleSystemScript;

    Unit affectedPlayerUnit;

    CardInstance affectedCard;

    public UpdatePlayerQueue playerQueue;

    public DamageBuffAction(CardInstance cardPassed)
    {
        battleSystemScript = GameObject.Find("BattleSystem");
        affectedCard = cardPassed;
    }

    public override void ApplyEffectAction(EffectActionData data)
    {
        affectedCard.viz.card.effect.cardEffectActionData.effectValue += data.effectValue;
    }
}
}