using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AK
{

[CreateAssetMenu(fileName = "Card Effect", menuName = "Card Effect")]
public class CardEffect : ScriptableObject
{   
    CardInstance cardInstance;
    Unit playerUnit;

    Unit enemyUnit;
    

    Card card;

    public EffectActionData cardEffectActionData;
    
    
    

    public CardEffect(CardInstance cardInst)
    {
        cardInstance = cardInst;
        card = cardInst.viz.card;
        

    }
    

    public void CheckConditions()
    {   

        
        switch (cardEffectActionData.type)
        {
            case EffectDataType.damage:
                DamageAction damageAction = new DamageAction();
                damageAction.enemyUnit = enemyUnit;
                damageAction.ApplyEffectAction(cardEffectActionData);
                break;

            case EffectDataType.defend:
                DefendAction defendAction = new DefendAction();
                defendAction.playerUnit = playerUnit;
                defendAction.ApplyEffectAction(cardEffectActionData);
                break;

            case EffectDataType.heal:
                HealAction healAction = new HealAction();
                healAction.playerUnit = playerUnit;
                healAction.ApplyEffectAction(cardEffectActionData);
                break;
            case EffectDataType.damagebuff:
                DamageBuffAction damageBuffAction = new DamageBuffAction();
                damageBuffAction.playerUnit = playerUnit;
                damageBuffAction.ApplyEffectAction(cardEffectActionData);
                break;
        }
    }
}
}