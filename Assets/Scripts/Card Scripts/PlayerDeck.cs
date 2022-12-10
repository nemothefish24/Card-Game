using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AK{

[CreateAssetMenu(menuName = "Holders/Player Deck Holder")]
public class PlayerDeck : ScriptableObject
{
    public List<Card> deckCards = new List<Card>();


}
}