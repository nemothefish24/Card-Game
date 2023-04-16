using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AK{


public abstract class CardType : ScriptableObject
{  
   public string typeName; 
   public bool canAttack;
   //public typelogic logic

   public virtual void OnSetType(CardViz viz)
   {

      Element t = Settings.GetResourcesManager().typeElement;
      CardVizProperties type = viz.GetProperty(t);
      type.text.text = typeName; 
   }

   public bool TypeAllowsForAttack(CardInstance cardInst)
   {
      if (canAttack)
         return true;

      else 
         return false;
   }

   
  
}

}
