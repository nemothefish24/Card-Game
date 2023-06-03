using System.Text.RegularExpressions;
using System.ComponentModel;
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
<<<<<<< Updated upstream
    public GameObject EnemyArea; 


    
=======
      
>>>>>>> Stashed changes

    public void DrawPlayerHand() //randomly draws cards
    {   
        
        ResourcesManager rm = Settings.GetResourcesManager();
        currentPlayer.playerHand.Clear();
        foreach (Transform child in currentPlayer.handGrid.value)
            {
                GameObject.Destroy(child.gameObject);
            }
        

        if (currentPlayer.playerDeck.deckCards.Count >= 5)
        {
            for (int i = 0; i < 5; i++)
            {
                Card randCard = currentPlayer.playerDeck.deckCards[Random.Range(0, currentPlayer.playerDeck.deckCards.Count)];
                currentPlayer.playerDeck.deckCards.Remove(randCard);
                currentPlayer.playerHand.Add(randCard);
                currentPlayer.refreshPile.Add(randCard);


                    //startingCards[i] = resources.allCards[Random.Range(0,resources.allCards.Length)];
            }
        }
        
        else
            {   
                if(currentPlayer.playerDeck.deckCards.Count > 0)
                {

                    int remainingCards = (5-currentPlayer.playerDeck.deckCards.Count);
                    
                    for (int i = 0; i <currentPlayer.playerDeck.deckCards.Count; i++)
                    {
                        Card randCard = currentPlayer.playerDeck.deckCards[Random.Range(0, currentPlayer.playerDeck.deckCards.Count)];
                        currentPlayer.playerDeck.deckCards.Remove(randCard);
                        currentPlayer.playerHand.Add(randCard);
                        currentPlayer.refreshPile.Add(randCard);

                    }

                    int refreshCount = currentPlayer.discardPile.Count;

                    for (int i = 0; i < refreshCount; i++)
                    {
                        Card refreshCard = currentPlayer.discardPile[0];
                        currentPlayer.discardPile.Remove(refreshCard);
                        currentPlayer.playerDeck.deckCards.Add(refreshCard);
              
                    }

                    for (int i = 0; i< remainingCards; i++)
                    {
                        Card randCard = currentPlayer.playerDeck.deckCards[Random.Range(0, currentPlayer.playerDeck.deckCards.Count)];
                        currentPlayer.playerDeck.deckCards.Remove(randCard);
                        currentPlayer.playerHand.Add(randCard);
                        currentPlayer.refreshPile.Add(randCard);
                    }
                }

        else
            {
                for (int i = 0; i < discardPile.Count; i++)
                {
                    currentPlayer.playerDeck.deckCards.Add(discardPile[i]);
                        currentPlayer.discardPile.Remove(discardPile[i]);
                }

                for (int i = 0; i < 2; i++)
                {
                Card randCard = currentPlayer.playerDeck.deckCards[Random.Range(0, currentPlayer.playerDeck.deckCards.Count)];
                currentPlayer.playerDeck.deckCards.Remove(randCard);
                currentPlayer.playerHand.Add(randCard);
                currentPlayer.refreshPile.Add(randCard);
                }
            }

            }
            int refreshint = currentPlayer.refreshPile.Count;
            for (int i = 0; i < refreshint; i++)
            {
                Card refreshCard = currentPlayer.refreshPile[0];
                currentPlayer.discardPile.Add(refreshCard);
                currentPlayer.refreshPile.Remove(refreshCard);
            }

            playerHandtoString();

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
        
    {

        Debug.Log("Button clicked.");

        DrawPlayerHand();

    }
        
    

    public void AddToDiscard()
    {
        for (int i = 0; i< 5; i++)
        {   Card usedCard = currentPlayer.playerHand[0];
            currentPlayer.playerHand.Remove(usedCard);
            discardPile.Add(usedCard);
        }
    }

    public void Update()
    {
        if (Input.GetKeyDown("o"))
            AddToDiscard();
    }
}
}