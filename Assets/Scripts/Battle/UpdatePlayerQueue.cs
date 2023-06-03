using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AK
{
public class UpdatePlayerQueue : MonoBehaviour
{
    public List <CardInstance> playerQueuedCards = new List<CardInstance>();

    public ActorHolder actor;

    public void UpdatePlayerQueuedCards() 
    {
        playerQueuedCards = actor.cardsDown;
        
    }
}
}