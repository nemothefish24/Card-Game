using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace AK
{
public class DrawCards : MonoBehaviour
{
    ResourcesManager rm;
    ActorHolder actor;
    
    public List<Card> discardPile = new List<Card>();
    public List <Card> playerHand = new List <Card>();

    

    public GameObject PlayerArea;
    public GameObject EnemyArea; 


    

    public void DrawPlayerHand() //randomly draws cards
    {   

        if (actor.playerDeck.Count >= 5)
        {
            for (int i = 0; i < 5; i++)
            {
                Card randCard = actor.playerDeck[Random.Range(0, actor.playerDeck.Count)];
                actor.playerDeck.Remove(randCard);
                playerHand.Add(randCard);
                
                
                //startingCards[i] = resources.allCards[Random.Range(0,resources.allCards.Length)];
            }
        }
        
        else 
            {
                int remainingCards = (5-actor.playerDeck.Count);
                
                for (int i = 0; i <actor.playerDeck.Count; i++)
                {
                    Card randCard = actor.playerDeck[Random.Range(0, actor.playerDeck.Count)];
                    actor.playerDeck.Remove(randCard);
                    playerHand.Add(randCard);
                }

                int refreshCount = discardPile.Count;

                for (int i = 0; i < refreshCount; i++)
                {
                    Card refreshCard = discardPile[0];
                    discardPile.Remove(refreshCard);
                    actor.playerDeck.Add(refreshCard);
                }

                for (int i = 0; i<remainingCards; i++)
                {
                    Card randCard = actor.playerDeck[Random.Range(0, actor.playerDeck.Count)];
                    actor.playerDeck.Remove(randCard);
                    playerHand.Add(randCard);
                }
            }
        
    }

        public void OnClick()
        
        
        {//create new playerCard 

        DrawPlayerHand();

        
        
        
    }
        
    }
}
