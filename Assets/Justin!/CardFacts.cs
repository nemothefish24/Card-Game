using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardFacts : MonoBehaviour
{
    public string valueText;
    public string suit;
    public int value;
    PokerScript poker;

    // Start is called before the first frame update
    void Start()
    {
        suit = name.Substring(0, 1);

        if (name.Length > 2)
        {
            valueText = name.Substring(1, 2);
        }

        else
        {
            valueText = name.Substring(1, 1);
        }

        int.TryParse(valueText, out value);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
