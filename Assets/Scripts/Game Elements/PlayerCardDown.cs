using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AK.GameElements{

[CreateAssetMenu(menuName = "Game Elements/Player Card Down")]
public class PlayerCardDown : GE_Logic
{
   
    public override void OnClick(CardInstance inst)
    {
        Debug.Log("This card is in my hand but on the table");
    }

    public override void OnHighlight(CardInstance inst)
    {
        
    }
}
}

