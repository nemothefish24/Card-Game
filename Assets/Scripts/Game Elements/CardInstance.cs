using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AK{
public class CardInstance : MonoBehaviour, IClickable //logic for the card interactibility 
{   
    public CardViz viz; 

    public AK.GameElements.GE_Logic currentLogic;

    void Start()
    {
        viz = GetComponent<CardViz>();
    }

    public bool CanAttack()
   {
      bool result = true;

      if (viz.card.cardType.typeName != "Attack")
      {
        result = false;
      }


      return result;
   }

    public void OnClick()
    {
        if (currentLogic == null)
            return;

        currentLogic.OnClick(this);
    }

    public void OnHighlight()
    {
        if (currentLogic == null)
            return;

       currentLogic.OnHighlight(this);
    }
}
}