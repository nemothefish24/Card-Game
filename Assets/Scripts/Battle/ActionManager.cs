using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AK{
public class ActionManager : MonoBehaviour
{   
    public List <CardInstance> playerQueuedCards = new List<CardInstance>();

    ActorHolder actor;

    public void UpdatePlayerQueuedCards() 
    {
        playerQueuedCards = actor.cardsDown;
    }
}
}