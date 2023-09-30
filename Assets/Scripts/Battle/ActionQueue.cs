using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

namespace AK
{
public class ActionQueue : MonoBehaviour
{
    
    Unit playerUnit;

    Unit enemyUnit;
    

    CardInstance cardToBuff;

    public EffectActionData cardEffectActionData;

    public UpdatePlayerQueue playerQueue;

    

    public List <CardInstance> temporaryPlayerQueue = new List<CardInstance>();

    public void ActionExecution()
    {   Debug.Log("Action execution started");
        if(playerQueue.playerQueuedCards[0].viz.card.effect.cardEffectActionData.type.ToString() == "damage")
            {
                CheckConditions(playerQueue.playerQueuedCards[0]);
                playerQueue.playerQueuedCards[0] = null;


                foreach (CardInstance cardToQueue in playerQueue.playerQueuedCards)
                    {   
                        if (cardToQueue.viz.card.effect.cardEffectActionData.type.ToString() == "damagebuff")
                            {
                                temporaryPlayerQueue.Add(cardToQueue);

                    
                            }

                        if (cardToQueue.viz.card.effect.cardEffectActionData.type.ToString() == "damage")
                            {
                            cardToBuff = cardToQueue;

                            Debug.Log(cardToBuff.viz.card.effect.cardEffectActionData.name + " has become the buffed action card and had a damage value of " + cardToBuff.viz.card.effect.cardEffectActionData.effectValue);
                            
                            foreach (CardInstance damageBuffCard in temporaryPlayerQueue)
                                {   
                                    CheckConditions(damageBuffCard);
                                    Debug.Log(damageBuffCard.viz.card.effect.cardEffectActionData.name + " has been added as a buff");
                                }

                            CheckConditions(cardToBuff);

                            Debug.Log("Buffed card did " + cardToBuff.viz.card.effect.cardEffectActionData.tempEffectValue + " damage.");

                            temporaryPlayerQueue.Clear();
                            
                            }
                    }
            }

        else
            foreach (CardInstance cardToQueue in playerQueue.playerQueuedCards)
            {   
                if (cardToQueue.viz.card.effect.cardEffectActionData.type.ToString() == "damagebuff")
                {
                    temporaryPlayerQueue.Add(cardToQueue);

                    
                }

                if (cardToQueue.viz.card.effect.cardEffectActionData.type.ToString() == "damage")
                {
                            cardToBuff = cardToQueue;

                            Debug.Log(cardToBuff.viz.card.effect.cardEffectActionData.name + " has become the buffed action card and had a damage value of " + cardToBuff.viz.card.effect.cardEffectActionData.effectValue);
                            
                            foreach (CardInstance damageBuffCard in temporaryPlayerQueue)
                                {   
                                    CheckConditions(damageBuffCard);
                                    Debug.Log(damageBuffCard.viz.card.effect.cardEffectActionData.name + " has been added as a buff");
                                }

                            CheckConditions(cardToBuff);

                            Debug.Log("Buffed card did " + cardToBuff.viz.card.effect.cardEffectActionData.tempEffectValue + " damage.");

                            temporaryPlayerQueue.Clear();
                            
                }

                if (cardToQueue.viz.card.effect.cardEffectActionData.type.ToString() == "defend")
                {
                    CheckConditions(cardToQueue);
                    Debug.Log(cardToQueue.viz.card.effect.cardEffectActionData.name + "has applied a shield of " + cardToQueue.viz.card.effect.cardEffectActionData.tempEffectValue);
                    temporaryPlayerQueue.Clear();
                }

            }

    
    }

    public void CheckConditions(CardInstance queuedCard)
    {   

        
        switch (queuedCard.viz.card.effect.cardEffectActionData.type)
        {
            case EffectDataType.damage:
                DamageAction damageAction = new DamageAction(queuedCard);
                damageAction.enemyUnit = enemyUnit;
                damageAction.ApplyEffectAction(queuedCard.viz.card.effect.cardEffectActionData);
                break;

            case EffectDataType.defend:
                DefendAction defendAction = new DefendAction(queuedCard);
                defendAction.playerUnit = playerUnit;
                defendAction.ApplyEffectAction(queuedCard.viz.card.effect.cardEffectActionData);
                break;

            case EffectDataType.heal:
                HealAction healAction = new HealAction();
                healAction.playerUnit = playerUnit;
                healAction.ApplyEffectAction(cardEffectActionData);
                break;
            case EffectDataType.damagebuff:
                DamageBuffAction damageBuffAction = new DamageBuffAction(cardToBuff);
                damageBuffAction.ApplyEffectAction(queuedCard.viz.card.effect.cardEffectActionData);
                break;
        }
    }


}
}