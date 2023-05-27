using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AK
{
public class DonkEffect : CardEffect
{   
    public int Damage;
    

    public DonkEffect(CardInstance cardInst) : base(cardInst)
    {
        Damage = cardInst.viz.card.properties[4].intValue;
        
    }


    
}
}