using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace AK{

[CreateAssetMenu(menuName = "Areas/PlayerCardsDownWhenHoldingCard")]
public class PlayerCardsDownAreaLogic : AreaLogic
{   
    public CardVariable card;
    public CardType attackType;
    public SO.TransformVariable areaGrid;
    public GameElements.GE_Logic cardDownLogic;

    public override void Execute()
    {
        if (card.value == null)
            return;
        
        if (card.value.viz.card.cardType != null) //checks if the card is of a certain type
        { //Places card down
            Settings.SetParentForCard(card.value.transform, areaGrid.value.transform);
            
            card.value.gameObject.SetActive(true);
            card.value.currentLogic = cardDownLogic;
        }
    }
}
}