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

    
    public string[] pickStartingCards()
    {   
        for (int i = 0; i < resources.allCards.Length; i++)
            {
                allCardStrings[i] = resources.allCards[i].ToString();
            }

        

        for (int i = 0; i < 5; i++)
            {
                startingCards[i] = allCardStrings[Random.Range(0, allCardStrings.Length)];
            }
        
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
