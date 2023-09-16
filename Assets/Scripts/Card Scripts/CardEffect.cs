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
    

    
}
}