using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace AK{
public class CardDisplay : MonoBehaviour
{
    public Card card; 
    public Text nameText;
    public Text descriptionText;

    public Image artworkImage;

    public Text manaText;
    public Text attackText;

    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log(card.name);

        /*
        nameText.text= card.name;
        descriptionText.text = card.cardDetail;
        artworkImage.sprite = card.art;

        manaText.text = card.manaCost.ToString();
        attackText.text = card.attack.ToString();
        */
    }
    
}
}