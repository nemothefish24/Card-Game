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

    // Start is called before the first frame update
    void Start()
    {
        state = BattleState.START;
        SetupBattle();
    }

    void SetupBattle()
    {
        Instantiate(playerPrefab, playerBattleStation);
        Instantiate(enemyPrefab1, enemyBattleStation);
    }
}
