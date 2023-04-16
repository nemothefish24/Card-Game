using System.Collections;
using System.Collections.Generic;
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
    public CardCalculator cardCalculator;

    public void BetChips()
    {
        if (chipStack >= betAmount)
        {
            currentChips += betAmount;
            chipStack -= betAmount;
        }
    }

    public void RiverEnd()
    {
        if (cardCalculator.winner == CardCalculator.Winner.Player)
        {
            chipStack += currentChips*2;
            currentChips = 0;
        }
        else
        {
            currentChips = 0;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        chipStack = startingChips;
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
