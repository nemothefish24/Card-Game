using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateSprite : MonoBehaviour
{
    public Sprite cardFace;
    public Sprite cardBack;
    private SpriteRenderer spriteRenderer;
    private Selectable selectable;
    private PokerScript poker;


    // Start is called before the first frame update
    void Start()
    {
        List<string> deck = PokerScript.GenerateDeck();
        poker = FindObjectOfType<PokerScript>();

        int i = 0;
        foreach (string card in deck)
        {
            if(this.name == card)
            { cardFace = poker.cardfaces[i];
                break;
            }
            i++;
        }
        spriteRenderer = GetComponent<SpriteRenderer>();
        selectable = GetComponent<Selectable>();
    }

    // Update is called once per frame
    void Update()
    {
        if (selectable.faceUp == true)
        {
            spriteRenderer.sprite = cardFace;
        }
        else
        { 
            spriteRenderer.sprite = cardBack;
        }
    }
}
