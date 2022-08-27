using System.Collections;
using UnityEngine;

namespace AK{

[CreateAssetMenu(menuName = "Cards/Attack")]
public class AttackCard : CardType
{
    public override void OnSetType(CardViz viz)
    {
        base.OnSetType(viz);

        viz.statsHolder.SetActive(true);

    }
}
}
