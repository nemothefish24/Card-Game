using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AK.GameStates;

namespace AK
{
public class GameManager : MonoBehaviour
{   
    public ActorHolder currentPlayer;
    public State currentState;
    public GameObject cardPrefab;
    
    public int turnIndex;
    public Turn[] turns; 

    private void Start()
    {
        Settings.gameManager = this; 
        CreateStartingCards();
    }

    void CreateStartingCards()
    {
        ResourcesManager rm = Settings.GetResourcesManager();

        for (int i = 0; i < currentPlayer.startingCards.Length; i++) //instantiates the starting cards
        {
            GameObject go = Instantiate(cardPrefab) as GameObject;
            CardViz v = go.GetComponent<CardViz>();
            v.LoadCard(rm.GetCardInstance(currentPlayer.startingCards[i])); //gets the instance and loads onto CardViz
            CardInstance inst = go.GetComponent<CardInstance>();
            inst.currentLogic = currentPlayer.handLogic;
            Settings.SetParentForCard(go.transform, currentPlayer.handGrid.value);
        }
    }

    private void Update()
    {   
        bool isComplete = turns[turnIndex].Execute();

        if (isComplete)
        {
            turnIndex++;
            if(turnIndex > turns.Length-1)
            {
                turnIndex = 0;
            }
        }

        if (currentState != null)
            currentState.Tick(Time.deltaTime);
    }

    public void SetState(State state) //control the state you want to go in 
    {
        currentState = state; 
    }
}
}
