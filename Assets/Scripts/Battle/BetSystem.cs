using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using UnityEngine;

public class BetSystem : MonoBehaviour
{

    public Chips chips;
    public BattleSystem battleSystem;
    public int startingChips;
    public int chipStack;
    public int currentChips;
    public int betAmount;
    public int rewardAmount;
    public int endingChips;
    public int betIncrement;
    public CardCalculator cardCalculator;
    public string betAmountText;
    public string currentChipsText;
    public string chipStackText;
    

    public void BetChips()
    {
        if (chipStack >= betAmount)
        {
            currentChips += betAmount;
            currentChipsText = currentChips.ToString();
            chipStack -= betAmount;
            chipStackText = chipStack.ToString();
        }
    }

    public void BetAdd()
    { 
        betAmount += betIncrement;
        betAmountText = betAmount.ToString();
    }

    public void BetMinus()
    {
        betAmount -= betIncrement;
        betAmountText = betAmount.ToString();
    }
    public void RiverEnd()
    {
        if (cardCalculator.winner == CardCalculator.Winner.Player)
        {
            chipStack += currentChips*2;
            chipStackText = chipStack.ToString(); 
            currentChips = 0;
            currentChipsText = "0";
        }

        else if (cardCalculator.winner == CardCalculator.Winner.Chop)
        {
            chipStack += currentChips;
            chipStackText = chipStack.ToString();
            currentChips = 0;
            currentChipsText = "0";
        }

        else
        {
            currentChips = 0;
            currentChipsText = "0";
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        chipStack = startingChips;
        chipStackText = chipStack.ToString();
        betAmountText = betAmount.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            BetChips();
        }
    }
}
