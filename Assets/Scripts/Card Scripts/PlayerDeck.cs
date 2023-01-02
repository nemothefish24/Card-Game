using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AK{

[CreateAssetMenu(menuName = "Holders/Player Deck Holder")]
public class PlayerDeck : ScriptableObject
{   
    ActorHolder actor;

    public List<Card> chosenDeck = new List<Card>();

    public List<Card> startingDeck = new List<Card>();
    public List<Card> deckCards = new List<Card>();

    


}
}