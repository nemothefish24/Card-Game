using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace AK
{
public class DrawCards : MonoBehaviour
{
    
    public ActorHolder currentPlayer;
    public GameObject cardPrefab;
    
    public List<Card> discardPile = new List<Card>();
    

    string[] playerHandStrings;

    public GameObject PlayerArea;
    public GameObject EnemyArea; 


    

    public void DrawPlayerHand() //randomly draws cards
    {   
        playerHandtoString();
        ResourcesManager rm = Settings.GetResourcesManager();

        if (currentPlayer.playerDeck.Count >= 5)
        {
            for (int i = 0; i < 5; i++)
            {
                Card randCard = currentPlayer.playerDeck[Random.Range(0, currentPlayer.playerDeck.Count)];
                currentPlayer.playerDeck.Remove(randCard);
                currentPlayer.playerHand.Add(randCard);
                
                
                //startingCards[i] = resources.allCards[Random.Range(0,resources.allCards.Length)];
            }
        }
        
        else
            {   
                if(currentPlayer.playerDeck.Count > 0)
                {

                    int remainingCards = (5-currentPlayer.playerDeck.Count);
                    
                    for (int i = 0; i <currentPlayer.playerDeck.Count; i++)
                    {
                        Card randCard = currentPlayer.playerDeck[Random.Range(0, currentPlayer.playerDeck.Count)];
                        currentPlayer.playerDeck.Remove(randCard);
                        currentPlayer.playerHand.Add(randCard);
                    }

                    int refreshCount = discardPile.Count;

                    for (int i = 0; i < refreshCount; i++)
                    {
                        Card refreshCard = discardPile[0];
                        discardPile.Remove(refreshCard);
                        currentPlayer.playerDeck.Add(refreshCard);
                    }

                    for (int i = 0; i< remainingCards; i++)
                    {
                        Card randCard = currentPlayer.playerDeck[Random.Range(0, currentPlayer.playerDeck.Count)];
                        currentPlayer.playerDeck.Remove(randCard);
                        currentPlayer.playerHand.Add(randCard);
                    }
                }

                else
                {
                    for (int i = 0; i < discardPile.Count; i++)
                    {
                        currentPlayer.playerDeck.Add(discardPile[i]);
                    }

                    for (int i = 0; i < 5; i++)
                    {
                    Card randCard = currentPlayer.playerDeck[Random.Range(0, currentPlayer.playerDeck.Count)];
                    currentPlayer.playerDeck.Remove(randCard);
                    currentPlayer.playerHand.Add(randCard);
                    
                    }
                }

            }

        for (int i = 0; i < playerHandStrings.Length; i++) //instantiates the cards
            
            {   
            
            GameObject go = Instantiate(cardPrefab) as GameObject;
            CardViz v = go.GetComponent<CardViz>();
            v.LoadCard(rm.GetCardInstance(playerHandStrings[i])); //gets the instance and loads onto CardViz
            CardInstance inst = go.GetComponent<CardInstance>();
            inst.currentLogic = currentPlayer.handLogic;
            Settings.SetParentForCard(go.transform, currentPlayer.handGrid.value);
            
            }
        
    }


    public string[] playerHandtoString()
    {   
        playerHandStrings = new string[currentPlayer.playerHand.Count];
        

        for (int i = 0; i < currentPlayer.playerHand.Count; i++)
            {
                playerHandStrings[i] = currentPlayer.playerHand[i].name.ToString();
            }
        
        return playerHandStrings;
    }

    
    public void OnClick()
        
    {//create new playerCard 

        Debug.Log("Button clicked.");

        DrawPlayerHand();

    }
        
    }
}
