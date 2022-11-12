using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AK
{

[CreateAssetMenu(menuName = "Holders/Card Holder")]
public class CardHolders : ScriptableObject
{
    public SO.TransformVariable handGrid;
    public SO.TransformVariable chipsGrid;
    public SO.TransformVariable downGrid;

    public void LoadPlayer(ActorHolder h)
    {
        foreach (CardInstance c in h.cardsDown)
        {
            c.viz.gameObject.transform.SetParent(downGrid.value.transform);

        }

        foreach (CardInstance c in h.handCards)
        {
            c.viz.gameObject.transform.SetParent(handGrid.value.transform);

        }

        
    }
}
}