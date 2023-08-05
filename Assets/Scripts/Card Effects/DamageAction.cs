using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace AK{
public class DamageAction : EffectAction
{   
    GameObject battleSystemScript;
    
    Unit affectedEnemyUnit;
          

    public DamageAction()
    {   battleSystemScript = GameObject.Find("BattleSystem");
        Debug.Log(battleSystemScript.name);
        affectedEnemyUnit = battleSystemScript.GetComponent<BattleSystem>().enemyUnit;
    }

    public override void ApplyEffectAction(EffectActionData data)
    {   
        Debug.Log("Action about to execute for value" + data.effectValue);
        affectedEnemyUnit.currentHP -= data.effectValue;
        Debug.Log("EnemyHP is now" + affectedEnemyUnit.currentHP);
    }
}
}