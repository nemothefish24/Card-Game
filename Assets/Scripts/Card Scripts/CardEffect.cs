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

            case EffectDataType.heal:
                break;
            case EffectDataType.buff:
                BuffAction buffAction = new BuffAction();
                buffAction.playerUnit = playerUnit;
                break;
        }
    }
}
}