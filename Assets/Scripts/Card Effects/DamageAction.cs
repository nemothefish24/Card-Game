using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace AK{
public class DamageAction : EffectAction
{   
    GameObject battleSystemScript;
    
    Unit affectedEnemyUnit;

    CardInstance passedActionCard;

    EffectActionData actionCardData;
          

    public DamageAction(CardInstance passedActionCard)
    {   battleSystemScript = GameObject.Find("BattleSystem");
        
        affectedEnemyUnit = battleSystemScript.GetComponent<BattleSystem>().enemyUnit;
        actionCardData = passedActionCard.viz.card.effect.cardEffectActionData;
    }

    public override void ApplyEffectAction(EffectActionData data)
    {   
        Debug.Log("Action about to execute for value" + data.effectValue);
        affectedEnemyUnit.currentHP -= actionCardData.effectValue;
        Debug.Log("EnemyHP is now" + affectedEnemyUnit.currentHP);
    }
}
}