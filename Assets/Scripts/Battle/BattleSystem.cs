using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum BattleState { START, PREFLOP, FLOP, TURN, RIVER, WON, LOST }

public class BattleSystem : MonoBehaviour
{

    public BattleState state;

    public GameObject playerPrefab;
    public GameObject enemyPrefab1;
    public GameObject enemyPrefab2;
    public GameObject enemyPrefab3; 
    public GameObject enemyPrefab4;

    public Transform playerBattleStation;
    public Transform enemyBattleStation;

    public PokerScript poker;
    public CardCalculator calc;
    public BetSystem blinds;

    Unit playerUnit;
    Unit enemyUnit;

    // Start is called before the first frame update
    void Start()
    {
        state = BattleState.START;
        StartCoroutine(SetupBattle());
    }

    IEnumerator SetupBattle()
    {
        GameObject playerGO = Instantiate(playerPrefab, playerBattleStation);
        playerUnit = playerGO.GetComponent<Unit>();

        GameObject enemyGO = Instantiate(enemyPrefab1, enemyBattleStation);
        enemyUnit = enemyGO.GetComponent<Unit>();

        Debug.Log("Battle Start");

        yield return new WaitForSeconds(1f);

        state = BattleState.PREFLOP;
        poker.PlayCards();
        calc.CalculateAll();
    }

    public void StateChange()
    {
        Debug.Log("Attempted State Change");

        if (state == BattleState.PREFLOP)
        {
            Debug.Log("Preflop True");
            state = BattleState.FLOP;
            poker.Flop();
            calc.CalculateAll();
            return;
        }

        if (state == BattleState.FLOP)
        {
            Debug.Log("Flop True");
            state = BattleState.TURN;
            poker.Turn();
            calc.CalculateAll();
            return;
        }

        if (state == BattleState.TURN)
        {
            Debug.Log("Turn True");
            state = BattleState.RIVER;
            poker.River();
            calc.CalculateAll();
            return;
        }

        if (state == BattleState.RIVER)
        {
            Debug.Log("River True");
            blinds.RiverEnd();

            //add win and loss
            //Add in execution of card effect

            state = BattleState.PREFLOP;
            poker.NewHand();
            poker.PlayCards();
            calc.CalculateAll();
            return;
        }

        else return;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            StateChange();
        }
    }
}
