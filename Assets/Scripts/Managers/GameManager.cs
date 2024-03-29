﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AK.GameStates;

namespace AK
{
public class GameManager : MonoBehaviour
{   
    public ActorHolder[] all_Actors;
    public ActorHolder currentPlayer;
    public CardHolders playerHolder;
    public CardHolders enemyHolder;
    public State currentState;
    public GameObject cardPrefab;
    
    public int turnIndex;
    public Turn[] turns; 

    public SO.GameEvent onTurnChanged;
    public SO.GameEvent onPhaseChanged; 
    public SO.StringVariable turnText;

    private void Start()
    {
        Settings.gameManager = this; 

        SetUpPlayers();

        CreateStartingCards();
        turnText.value = turns[turnIndex].player.username;
        onTurnChanged.Raise();
    }

    void SetUpPlayers()
    {
        foreach (ActorHolder a in all_Actors)
        {
            if (a.isHumanPlayer)
            {
                a.currentHolder = playerHolder;
            }

            else{
                a.currentHolder = enemyHolder;
            }
        }
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

            turnText.value = turns[turnIndex].player.username; //sets the turn text 
            onTurnChanged.Raise(); //raises the event for turn change
        }

        if (currentState != null)
            currentState.Tick(Time.deltaTime);
    }

    public void SetState(State state) //control the state you want to go in 
    {
        currentState = state; 
    }

    public void EndCurrentPhase()
    {
        turns[turnIndex].EndCurrentPhase();
    }
}
}
