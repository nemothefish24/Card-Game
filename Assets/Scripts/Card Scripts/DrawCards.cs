using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace AK
{
public class DrawCards : MonoBehaviour
{
    ResourcesManager rm;
    
    public List<Card> discardPile = new List<Card>();
    public List <Card> playerHand = new List <Card>();

    public List<Card> playerDeck = new List<Card>();

    public GameObject PlayerArea;
    public GameObject EnemyArea; 


    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i<rm.allCards.Length; i++)
        {
            playerDeck.Add(rm.allCards[i]); //temporary, will change what cards are initially added to playerDeck

            
        }

    }

    

    public void DrawPlayerHand() //randomly generates the starting cards 
    {   

        if (playerDeck.Count >= 5)
        {
            for (int i = 0; i < 5; i++)
            {
                Card randCard = playerDeck[Random.Range(0, playerDeck.Count)];
                playerDeck.Remove(randCard);
                playerHand.Add(randCard);
                
                
                //startingCards[i] = resources.allCards[Random.Range(0,resources.allCards.Length)];
            }
        }
        
        else 
            {
                int remainingCards = (5-playerDeck.Count);
                
                for (int i = 0; i <playerDeck.Count; i++)
                {
                    Card randCard = playerDeck[Random.Range(0, playerDeck.Count)];
                    playerDeck.Remove(randCard);
                    playerHand.Add(randCard);
                }

                int refreshCount = discardPile.Count;

                for (int i = 0; i < refreshCount; i++)
                {
                    Card refreshCard = discardPile[0];
                    discardPile.Remove(refreshCard);
                    playerDeck.Add(refreshCard);
                }

                for (int i = 0; i<remainingCards; i++)
                {
                    Card randCard = playerDeck[Random.Range(0, playerDeck.Count)];
                    playerDeck.Remove(randCard);
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
