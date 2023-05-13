using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AK
{

[CreateAssetMenu(fileName = "Card Effect", menuName = "Card Effect")]
public class CardEffect : ScriptableObject
{   
    public CardInstance CardInst;
    public Unit playerUnit;
    public Unit enemyUnit;

    public EffectActionData cardEffectActionData;
    public EffectAction effectAction;
    public DamageAction damageAction;

    public CardEffect(CardInstance cardInst)
    {
        CardInst = cardInst;
    }
    

    public void CheckConditions()
    {
        switch (cardEffectActionData.type)
        {
            case EffectDataType.damage:
                damageAction.ApplyEffectAction(cardEffectActionData);
                break;

            case EffectDataType.heal:
                break;
            case EffectDataType.buff:
                break;
        }
    }
}
}