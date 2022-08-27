using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawCards : MonoBehaviour
{
    public GameObject actionCard1; 
    public GameObject actionCard2;
    

    public GameObject PlayerArea;
    public GameObject EnemyArea; 

    List <GameObject> playerDeck = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        playerDeck.Add(actionCard1);
        playerDeck.Add(actionCard2);
    }

    public void OnClick()
    {   //create new playerCard 

        for (int i = 0; i < 5; i++)
        {
            GameObject playerCard = Instantiate(playerDeck[Random.Range(0,playerDeck.Count)], new Vector3(0, 0, 0), Quaternion.identity);
            
            //Sets it so that the card becomes a child of the PlayerArea so it nests in the canvas 
            playerCard.transform.SetParent(PlayerArea.transform, false);

            GameObject enemyCard = Instantiate(actionCard1, new Vector3(0,0,0), Quaternion.identity);
            enemyCard.transform.SetParent(EnemyArea.transform,false);
        }
        

        
    }
}
