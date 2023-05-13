using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AK
{
public abstract class CardEffect
{   
    public CardInstance CardInst;
    public Unit playerUnit;
    public Unit enemyUnit;

    public CardEffect(CardInstance cardInst)
    {
        CardInst = cardInst;
    }
    

    public virtual void ActivateCardEffect()
    {

    }
}
}