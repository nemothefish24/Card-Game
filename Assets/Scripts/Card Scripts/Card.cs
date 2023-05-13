using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AK{
[CreateAssetMenu(menuName = "Card")]
public class Card : ScriptableObject
{   
    public CardType cardType;
    public CardProperties[] properties;

    [SerializeReference]
    public CardEffect effect;
    
    
    
    
}
}
