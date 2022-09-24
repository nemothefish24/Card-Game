using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace AK
{
public class ChipsManager : MonoBehaviour
{
    public Slider chipsSlider;
    public int playedChips;

    public int chipsToPlay;

    ChipsHolder chipsHolder;

    ActorHolder player;

    
    void Update()
    {   
        chipsSlider.minValue = 0;
        chipsSlider.maxValue = chipsHolder.chipsCount;
        chipsToPlay = (int)chipsSlider.value;
    }



    void PlayChips()
    {
        playedChips = (int)chipsSlider.value; 
        
        player.UseChips(playedChips);
    }
}
}