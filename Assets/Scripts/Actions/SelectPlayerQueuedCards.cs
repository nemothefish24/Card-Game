using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AK.GameStates;
using UnityEngine.EventSystems;

namespace AK{

[CreateAssetMenu(menuName = "Actions/SelectPlayerQueuedCards")]
public class SelectPlayerQueuedCards : Action
{   
    ActionManager manager;
   public override void Execute (float d)
   {
        if (Input.GetMouseButtonDown(0))
        {                  
            List<RaycastResult> results = Settings.GetUIObjects();
        
            foreach (RaycastResult r in results)
            {   
                CardInstance cardInst = r.gameObject.GetComponentInParent<CardInstance>();
                ActorHolder a = Settings.gameManager.currentPlayer;

                
                if (Settings.gameManager.currentPlayer.cardsDown.Contains(cardInst))
                {   manager.playerQueuedCards.Add(cardInst);
                    return;
                }
                
            }
   }
}
}
}