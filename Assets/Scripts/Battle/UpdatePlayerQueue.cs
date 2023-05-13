using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AK
{
public class UpdatePlayerQueue : MonoBehaviour
{
    public List <CardInstance> playerQueuedCards = new List<CardInstance>();

    public ActorHolder actor;

    public List<CardInstance> UpdatePlayerQueuedCards() 
    {
        playerQueuedCards = actor.cardsDown;
        return playerQueuedCards;
    }
}
}