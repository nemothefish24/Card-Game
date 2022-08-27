using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AK.GameElements
{

[CreateAssetMenu(menuName = "Game Elements/Player Hand Card")]
public class PlayerHandCards : GE_Logic
{   
    public SO.GameEvent onCurrentCardSelected;
    public CardVariable currentCard;
    public AK.GameStates.State holdingCard; 

    public override void OnClick(CardInstance inst)
    {
        currentCard.Set(inst); //changes the state of the card so it's movable
        Settings.gameManager.SetState(holdingCard);
        onCurrentCardSelected.Raise(); //raise this game event
    }

    public override void OnHighlight(CardInstance inst)
    {
        
    }
}
}