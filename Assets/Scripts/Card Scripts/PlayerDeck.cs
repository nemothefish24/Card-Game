using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AK{

[CreateAssetMenu(menuName = "Holders/Player Deck Holder")]
public class PlayerDeck : ScriptableObject
{   
    ActorHolder actor;

    public List<string> chosenDeck = new List<string>();

    public List<string> startingDeck = new List<string>();
    public List<Card> deckCards = new List<Card>();

    void Start()
    {   
        for (int i = 0; i < chosenDeck.Count; i++)
        {
            startingDeck[i] = chosenDeck[i];
        
        }

        
    }


}
}