using System.Collections;
using UnityEngine;

namespace AK{

[CreateAssetMenu(menuName = "Cards/Utility")]
public class UtilityCard : CardType
{
    public override void OnSetType(CardViz viz)
    {
        base.OnSetType(viz);

        viz.statsHolder.SetActive(false);

    }
}
}
