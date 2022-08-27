﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace AK.GameStates
{

[CreateAssetMenu(menuName = "Actions/MouseHoldWithCard")]
public class MouseHoldWithCard : Action
{   
    public CardVariable currentCard; 
    public State playerControlState;
    public SO.GameEvent onPlayerControlState;

    public override void Execute(float d)
    {
        bool mouseIsDown = Input.GetMouseButton(0);

        if (!mouseIsDown)
        {   
            List<RaycastResult> results = Settings.GetUIObjects();          

            foreach (RaycastResult r in results)
            {//Check for droppable areas 
                GameElements.Area a = r.gameObject.GetComponentInParent<GameElements.Area>();

                if (a != null)
                {   
                    a.OnDrop();
                    break;
                }
            }
            
            currentCard.value.gameObject.SetActive(true);         
            currentCard.value = null;
            

            Settings.gameManager.SetState(playerControlState); //sets a condition for changing the state
            onPlayerControlState.Raise();
            return;
        }
    }
}
}