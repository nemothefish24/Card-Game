using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AK
{
public class CurrentSelected : MonoBehaviour
{
    public CardVariable currentCard;
    public CardViz cardViz; 

    Transform mTransform;

    public void LoadCard() //used for dragging cards 
    {
        if (currentCard.value == null)
            return;
        
        currentCard.value.gameObject.SetActive(false); //remove from hand
        cardViz.LoadCard(currentCard.value.viz.card); //place on mouse
        cardViz.gameObject.SetActive(true); //
    }

    public void CloseCard()
    {   
        Debug.Log ("card closed");
        cardViz.gameObject.SetActive(false);
        Debug.Log ("card disappeared");
    }

     private void Start()
    {
        mTransform = this.transform;
        CloseCard();
    }
      
    void Update()
    {
        mTransform.position = Input.mousePosition; 
    }
}
}
