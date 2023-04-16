using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace AK{
public class UpdatePlayerQueuedCards : MonoBehaviour
{   
    ActionManager actionManager;

    public List <CardInstance> playerQueuedCards = new List<CardInstance>();

    ActorHolder actor;

    public void RefreshPlayerQueuedCards() 
    {
        playerQueuedCards = actor.cardsDown;
    }
}
}