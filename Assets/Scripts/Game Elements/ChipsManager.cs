using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace AK
{
public class ChipsManager : MonoBehaviour
{
    public Slider chipsSlider;
    public int playedChips;

    public int chipsToPlay;

    public ChipsHolder chipsHolder;

    public ActorHolder player;

    public TMP_Text chipsText;

    
    void Start()
    {   
        chipsSlider.minValue = 0;
        chipsSlider.maxValue = chipsHolder.chipsCount;
    }

    void Update()
    {   
        chipsSlider.minValue = 0;
        chipsSlider.maxValue = chipsHolder.chipsCount;
        chipsToPlay = (int)chipsSlider.value;
        chipsText.text = chipsHolder.chipsCount.ToString();
    }



    void PlayChips()
    {
        playedChips = (int)chipsSlider.value; 
        
        player.UseChips(playedChips);
    }
}
}