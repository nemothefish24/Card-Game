using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PokerScript : MonoBehaviour

{
    public Sprite[] cardfaces;
    public GameObject cardprefab;
    public static string[] suits = new string[] { "C", "D", "H", "S" };
    public static string[] values = new string[] { "A", "K", "Q", "J", "10", "9", "8", "7", "6", "5", "4", "3", "2" };
    public CardFacts cardfacts;
    public List<string> deck;
    public List<string> playerhand;
    public List<string> enemyhand;
    public List<string> board;
    //public List<Card> deck1 = new List<Card>();
    public Transform[] cardSlots;
    public bool[] availableCardSlots;
    public GameObject playerarea;
    public GameObject enemyarea;
    public GameObject boardarea;
    public List<string> playerfinalhand;
    public List<string> enemyfinalhand;
    public List<string> playersuits;
    public List<string> playervalues;
    public List<string> enemysuits;
    public List<string> enemyvalues;
    public CardCalculator cardCalculator;
    


    /*public void DrawCard()
    {
        Card randCard = deck[UnityEngine.Random.Range(0, deck.Count)];

        for (int i = 0; i < availableCardSlots.Length; i++)
        {
            if(availableCardSlots[i] == true)
            {
                randCard.gameObject.SetActive(true);
                availableCardSlots[i] = false;
                deck.Remove(randCard);
                return;
            }
        }

    }*/

       

        public void PlayCards()
        {
            deck = GenerateDeck();
            Shuffle(deck);
            foreach (string card in deck)
            {
                print(card);
            }
            PokerDeal();
            FlipEm();
        }
    
    public static List<string> GenerateDeck()
    {
        List<string> newDeck = new List<string>();
        foreach (string s in suits)
        {
            foreach (string v in values)
            {
                newDeck.Add(s + v);
            }
        }
        return newDeck;
    }
    
    void Shuffle<T>(List<T> list)
    {
        System.Random random = new System.Random();
        int n = list.Count;
        while (n > 1)
        { int k = random.Next(n);
            n--;
            T temp = list[k];
            list[k] = list[n];
            list[n] = temp;
        }
    }

    void PokerDeal()
    {
        for (int i = 0; i < 2; i++)
        {
            string playerCard = deck[0];
            deck.Remove(playerCard);
            playerhand.Add(playerCard);
            playerfinalhand.Add(playerCard);
            playersuits.Add(playerCard.Substring(0,1));
            if(playerCard.Length > 2)
            {
                playervalues.Add(playerCard.Substring(1,2));
            }
            else
            {
                playervalues.Add(playerCard.Substring(1, 1));
            }
            
        }

        foreach (string card in playerhand)
        {
            GameObject newCard = Instantiate(cardprefab, new Vector3(0,0,0), Quaternion.identity);
            newCard.name = card;
            newCard.transform.SetParent(playerarea.transform, false);
            newCard.GetComponent<Selectable>().faceUp = true;
        }

            

        for (int i = 0; i < 2; i++)
        {
            string enemyCard = deck[0];
            deck.Remove(enemyCard);
            enemyhand.Add(enemyCard);
            enemyfinalhand.Add(enemyCard);
            enemysuits.Add(enemyCard.Substring(0, 1));
            if (enemyCard.Length > 2)
            {
                enemyvalues.Add(enemyCard.Substring(1, 2));
            }
            else
            {
                enemyvalues.Add(enemyCard.Substring(1, 1));
            }

        }

        foreach (string card in enemyhand)
        {
            GameObject newCard = Instantiate(cardprefab, new Vector3(0, 0, 0), Quaternion.identity);
            newCard.name = card;
            newCard.transform.SetParent(enemyarea.transform, false);
            newCard.GetComponent<Selectable>().faceUp = true;
        }

        for (int i = 0; i < 5; i++)
        {
            string boardCard = deck[0];
            deck.Remove(boardCard);
            board.Add(boardCard);

        }

        foreach (string card in board)
        {
            GameObject newCard = Instantiate(cardprefab, new Vector3(0, 0, 0), Quaternion.identity);
            newCard.name = card;
            newCard.transform.SetParent(boardarea.transform, false);
        }

        

        foreach (string card in deck)
        {
            GameObject newCard = Instantiate(cardprefab, transform.position, Quaternion.identity);
            newCard.name = card;
            //newCard.GetComponent<Selectable>().faceUp = true;



            for (int i = 0; i < availableCardSlots.Length; i++)
            {
                if (availableCardSlots[i] == true)
                {
                    newCard.transform.position = cardSlots[i].position;
                    availableCardSlots[i] = false;
                    deck.Remove(card);

                    return;

                }
            }


            //newCard.GetComponent<Selectable>().faceUp = true;
        }
    }

    void FlipEm()
    {

    }

    /*void PokerSort()
    {
        for (int i = 0; i < 3; i++)
        {
            for (int j = i; j < 3; j++)
        }
    }*/
    void Flop()
    {
        for (int i = 0; i < 3; i++)
        {
            boardarea.transform.GetChild(i).GetComponent<Selectable>().faceUp = true;
            playerfinalhand.Add(board[i]);
            playersuits.Add(board[i].Substring(0, 1));
            if (board[i].Length > 2)
            {
                playervalues.Add(board[i].Substring(1, 2));
            }
            else
            {
                playervalues.Add(board[i].Substring(1, 1));
            }
            enemyfinalhand.Add(board[i]);
            enemysuits.Add(board[i].Substring(0, 1));
            if (board[i].Length > 2)
            {
                enemyvalues.Add(board[i].Substring(1, 2));
            }
            else
            {
                enemyvalues.Add(board[i].Substring(1, 1));
            }
        }
    }
    void Turn()
    {
        for (int i = 0; i < 4; i++)
        {
            boardarea.transform.GetChild(i).GetComponent<Selectable>().faceUp = true;
        }
        playerfinalhand.Add(board[3]);
        playersuits.Add(board[3].Substring(0, 1));
        if (board[3].Length > 2)
        {
            playervalues.Add(board[3].Substring(1, 2));
        }
        else
        {
            playervalues.Add(board[3].Substring(1, 1));
        }
        enemyfinalhand.Add(board[3]);
        enemysuits.Add(board[3].Substring(0, 1));
        if (board[3].Length > 2)
        {
            enemyvalues.Add(board[3].Substring(1, 2));
        }
        else
        {
            enemyvalues.Add(board[3].Substring(1, 1));
        }
    }
    void River()
    {
        for (int i = 0; i < 5; i++)
        {
            boardarea.transform.GetChild(i).GetComponent<Selectable>().faceUp = true;
        }
        playerfinalhand.Add(board[4]);
        playersuits.Add(board[4].Substring(0, 1));
        if (board[4].Length > 2)
        {
            playervalues.Add(board[4].Substring(1, 2));
        }
        else
        {
            playervalues.Add(board[4].Substring(1, 1));
        }
        enemyfinalhand.Add(board[4]);
        enemysuits.Add(board[4].Substring(0, 1));
        if (board[4].Length > 2)
        {
            enemyvalues.Add(board[4].Substring(1, 2));
        }
        else
        {
            enemyvalues.Add(board[4].Substring(1, 1));
        }
    }

    void NewHand()
    {
        GameObject[] allCards = GameObject.FindGameObjectsWithTag("Poker");
        foreach (GameObject card in allCards) 
        {
            Destroy(card);
        }
        deck.Clear();
        playerhand.Clear();
        enemyhand.Clear();
        board.Clear();
        playerfinalhand.Clear();
        enemyfinalhand.Clear();
        playersuits.Clear();
        playervalues.Clear();
        enemysuits.Clear();
        enemyvalues.Clear();
        cardCalculator.playerhandtype = "";
        cardCalculator.playercardtext = "";
}

    private void Start()
    {
        //playerhand = new List<string>[] { player0, player1 };
        //PlayCards();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PlayCards();
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            Flop();
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            Turn();
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            River();
        }
        if (Input.GetKeyDown(KeyCode.V))
        {
            NewHand();
        }
    }
}

