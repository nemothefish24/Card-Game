using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AK.GameElements;

namespace AK
{

[CreateAssetMenu(menuName = "Holders/Actor Holder")]
public class ActorHolder : ScriptableObject
{   

    public string username; 
    public string[] startingCards;  
    string[] allCardStrings;

    string[] playerDeckStrings;

    public PlayerDeck playerDeck;

    List <Card> startingCardObjects = new List<Card>();

    public List <Card> playerHand = new List <Card>();

    public List <Card> discardPile = new List <Card>();

    public List <Card> refreshPile = new List <Card> ();
  
    public SO.TransformVariable handGrid;
    public SO.TransformVariable chipsGrid;
    public SO.TransformVariable downGrid;
    
    public ChipsHolder chips; 

    public bool isHumanPlayer;

    public ResourcesManager resources;

    public int chipsPerTurn;
    [System.NonSerialized]
    public int chipsUsedThisTurn;

    public GE_Logic handLogic;
    public GE_Logic downLogic; 

    [System.NonSerialized]
    public CardHolders currentHolder;

    [System.NonSerialized]
    public List<CardInstance> handCards = new List<CardInstance>();
    [System.NonSerialized]
    public List <CardInstance> cardsDown = new List<CardInstance>();

    
    // Start is called before the first frame update

    /*
    void Start()
    {
        for (int i = 0; i<resources.allCards.Length; i++)
        {
            playerDeck.Add(resources.allCards[i]); //temporary, will change what cards are initially added to playerDeck

            
        }

    }
    */
    public string[] pickStartingCards()
    {   
        playerDeck.startingDeck.Clear();
        playerDeck.deckCards.Clear();
        playerHand.Clear();
        refreshPile.Clear();
        discardPile.Clear();

        for (int i = 0; i < playerDeck.chosenDeck.Count; i++)
        {   
            
            playerDeck.startingDeck.Add(playerDeck.chosenDeck[i]);
            
        }



        for (int i = 0; i < playerDeck.chosenDeck.Count; i++)
        {
            
            playerDeck.deckCards.Add(playerDeck.startingDeck[i]);
        
        }

        if (playerDeck.deckCards.Count >= 5)
        {
            for (int i = 0; i < 5; i++)
            {
                Card randCard = playerDeck.deckCards[Random.Range(0, playerDeck.deckCards.Count)];
                playerDeck.deckCards.Remove(randCard);
                playerHand.Add(randCard);
                refreshPile.Add(randCard);
                
                
                //startingCards[i] = resources.allCards[Random.Range(0,resources.allCards.Length)];
            }
        }
            int refreshint = refreshPile.Count;
            for (int i = 0; i < refreshint; i++)
            {
                Card refreshCard = refreshPile[0];
                discardPile.Add(refreshCard);
                refreshPile.Remove(refreshCard);
                
            }

            for (int i = 0; i < 5; i++)
            {
                startingCards[i] = playerHand[i].name;
                
                
                //startingCards[i] = resources.allCards[Random.Range(0,resources.allCards.Length)];
            }

        /*
        playerDeckStrings = new string[playerDeck.deckCards.Count];
        startingCards = new string[5]; 

        for (int i = 0; i < playerDeck.deckCards.Count; i++)
            {
                playerDeckStrings[i] = playerDeck.deckCards[i].name.ToString();
            }

        

        for (int i = 0; i < 5; i++)
            {
                startingCards[i] = playerDeckStrings[Random.Range(0, playerDeckStrings.Length)];
                
            }
        
        */
        return startingCards;
        
    }



    public int chipsCount()
    {
        //get {return chipsGrid.value.GetComponent<Chips>().chipsCount.value};

        int playerChips = chips.chipsCount;

        return playerChips;
    }

    public void AddChips(int newChips) //Handles adding new chips 
    {
        /*ChipsHolder chipsHolder = new ChipsHolder
        {
            chipsCount = newChips
        };*/

        chips.chipsCount += newChips; 
    }

    public int NonUsedChips()
    {   
        
        if (chips.chipsCount != 0)
            return chips.chipsCount;
        else
            return 0;
        
    }

    public bool CanUseChips(ChipsHolder c)
    {
        bool result = true;

        int currentChips = NonUsedChips();

        if (currentChips > 0)
            result = true;
        else 
            result = false;

        return result;
    }

    public void UseChips (int amount)
    {
         //need to integrate player selection of how many chips to use
        

        int currentChips = NonUsedChips();

        currentChips -= chipsUsedThisTurn; 
    }

    public int GetUnusedChips()
    {
       int unusedChips = NonUsedChips();
       return unusedChips;

    }    

}
}
