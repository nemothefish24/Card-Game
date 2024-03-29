﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace AK.GameStates
{

[CreateAssetMenu(menuName = "Actions/MouseOverDetection")]
public class MouseOverDetection : Action //gets a raycast to check the element its above
{
    public override void Execute(float d)
    {
        
        List<RaycastResult> results = Settings.GetUIObjects();
        

        IClickable c = null;

        foreach (RaycastResult r in results)
        {
            c = r.gameObject.GetComponentInParent<IClickable>();
            
            if (c != null)
            {
                c.OnHighlight();
                break;
            }

            else
            {
                
            }
        }          
        
}
}
}

    
    

        
        
        



