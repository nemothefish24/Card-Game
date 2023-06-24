using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleMultiplier : MonoBehaviour
{

    public CardCalculator calc;
    public int multiplier;

    public void calculateMultiplier() {
        if (calc.playerState == CardCalculator.Hand.RoyalFlush)
        {
            multiplier = 781 / 10;
        }

        if (calc.playerState == CardCalculator.Hand.Straightflush)
        {
            multiplier = 375 / 10;
        }

        if (calc.playerState == CardCalculator.Hand.Quads)
        {
            multiplier = 145 / 10;
        }

        if (calc.playerState == CardCalculator.Hand.Fullhouse)
        {
            multiplier = 79 / 10;
        }

        if (calc.playerState == CardCalculator.Hand.Flush)
        {
            multiplier = 72/10;
        }

        if (calc.playerState == CardCalculator.Hand.Straight)
        {
            multiplier = 57/10;
        }

        if (calc.playerState == CardCalculator.Hand.Triple)
        {
            multiplier = 32/10;
        }

        if (calc.playerState == CardCalculator.Hand.Twopair)
        {
            multiplier = 24/10;
        }

        if (calc.playerState == CardCalculator.Hand.Pair)
        {
            multiplier = 15/10;
        }

        if (calc.playerState == CardCalculator.Hand.Topcard)
        {
            multiplier = 11/10;
        }

        if (calc.playerState == CardCalculator.Hand.Calculating)
        {
            return;
        }
        
    }
   
}
