using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using UnityEngine;

public class CardCalculator : MonoBehaviour
{
    public PokerScript poker;
    public List<string> player;
    public List<string> enemy;
    public List<int> playerHandvalues;
    public List<int> enemyHandvalues;
    public string playerhandtype;
    public string enemyhandtype;
    private string suit;
    private int value;
    public List<string> playersuits;
    public List<string> enemysuits;
    public List<string> playervaluesText;
    public List<string> enemyvaluesText;
    public List<int> playervalues;
    public List<int> enemyvalues;
    public List<string> playersuitTEST;
    public int playerflushcounter;
    public int enemyflushcounter;
    public bool playerstraight;
    public int playerstraighthigh;
    public bool playerflush;
    public int playerflushhigh;
    public int playerflushkicker;
    public bool enemystraight;
    public int enemystraighthigh;
    public bool enemyflush;
    public int enemyflushhigh;
    public int enemyflushkicker;
    public List<string> playerbesthand;
    public List<string> enemybesthand;
    public List<string> playerflushboard;
    public List<string> enemyflushboard;
    public List<int> playerflushvalues;
    public List<int> enemyflushvalues;
    public List<int> playerbestvalues;
    public List<int> enemybestvalues;
    public string playerhigh;
    public string enemyhigh;
    public int playerpair1;
    public int playerpair2;
    public int playertrip1;
    public int playertrip2;
    public int playerquad;
    public int playerkicker;
    public int playerkicker2;
    public int playerkicker3;
    public int playerkicker4;
    public int playerkicker5;
    public int playerfh1;
    public int playerfh2;
    public int enemypair1;
    public int enemypair2;
    public int enemytrip1;
    public int enemytrip2;
    public int enemyquad;
    public int enemykicker;
    public int enemykicker2;
    public int enemykicker3;
    public int enemykicker4;
    public int enemykicker5;
    public int enemyfh1;
    public int enemyfh2;
    public string playercardtext;
    public int playercard1;
    public int playercard2;
    public string playercard1text;
    public string playercard2text;

    public Hand playerState;
    public Hand enemyState;
    public Winner winner;


    public enum Hand
    {
        Calculating,
        Topcard,
        Pair,
        Twopair,
        Triple,
        Straight,
        Flush,
        Fullhouse,
        Quads,
        Straightflush,
        RoyalFlush
    }

    public enum Winner
    {
        Calculating,
        Player,
        Enemy,
        Chop
    }
    
    
    string IntToString(int number)
    {
        string result;
        if(number == 2)
        {
            result = "Two";
        }
        else if (number == 3)
        {
            result = "Three";
        }
        else if (number == 4)
        {
            result = "Four";
        }
        else if (number == 5)
        {
            result = "Five";
        }
        else if (number == 6)
        {
            result = "Six";
        }
        else if (number == 7)
        {
            result = "Seven";
        }
        else if (number == 8)
        {
            result = "Eight";
        }
        else if (number == 9)
        {
            result = "Nine";
        }
        else if (number == 10)
        {
            result = "Ten";
        }
        else if (number == 11)
        {
            result = "Jack";
        }
        else if (number == 12)
        {
            result = "Queen";
        }
        else if (number == 13)
        {
            result = "King";
        }
        else if (number == 14)
        {
            result = "Ace";
        }
        else
        {
            result = "";
        }
        //Debug.Log(result + " this is the result");

        return result;
    }
    public void UpdateCardText()
    {
        if(playerState == Hand.RoyalFlush)
        {
            return;
        }

        if(playerState == Hand.Straightflush)
        {
            playercardtext = IntToString(playercard1) + " high";
        }

        if(playerState == Hand.Quads)
        {
            if (playercard1 == 6)
            {
                playercardtext = IntToString(playercard1) + "es";
            }
            else
            {
                playercardtext = IntToString(playercard1) + "s";
            }
        }

        if(playerState == Hand.Fullhouse)
        {
            if (playercard1 == 6)
            {
                playercardtext = IntToString(playercard1) + "es" + " and " + IntToString(playercard2) + "s";
            }
            else if (playercard2 == 6)
            {
                playercardtext = IntToString(playercard1) + "s" + " and " + IntToString(playercard2) + "es";
            }
            else
            {
                playercardtext = IntToString(playercard1) + "s" + " and " + IntToString(playercard2) + "s";
            }
        }

        if(playerState == Hand.Flush)
        {
            playercardtext = IntToString(playercard1) + " high";
        }

        if(playerState == Hand.Straight)
        {
            playercardtext = IntToString(playercard1) + " high";
        }

        if(playerState == Hand.Triple)
        {
            if (playercard1 == 6)
            {
                playercardtext = IntToString(playercard1) + "es";
            }
            else
            {
                playercardtext = IntToString(playercard1) + "s";
            }
        }

        if(playerState == Hand.Twopair)
        {
            if (playercard1 == 6)
            {
                playercardtext = IntToString(playercard1) + "es" + " and " + IntToString(playercard2) + "s";
            }
            else if (playercard2 == 6)
            {
                playercardtext = IntToString(playercard1) + "s" + " and " + IntToString(playercard2) + "es";
            }
            else
            {
                playercardtext = IntToString(playercard1) + "s" + " and " + IntToString(playercard2) + "s";
            }
        }

        if(playerState == Hand.Pair)
        {
            if (playercard1 == 6)
            {
                playercardtext = IntToString(playercard1) + "es";
            }
            else
            {
                playercardtext = IntToString(playercard1) + "s";
            }
        }
        
        if(playerState == Hand.Topcard)
        {
            playercardtext = IntToString(playercard1);
        }

        if(playerState == Hand.Calculating)
        {
            return;
        }
        Debug.Log(playercardtext);
        Debug.Log(playercard1);
        
    }
    public void CompareState()
    {
        if ((int)enemyState > (int)playerState)
        {
            Debug.Log("Enemy wins"); winner = Winner.Enemy;
        }
        if ((int)enemyState < (int)playerState)
        {
            Debug.Log("Player wins"); winner = Winner.Player;
        }
        if ((int)enemyState == (int)playerState)
        { 
            //Royal
            if(playerState == Hand.RoyalFlush)
            {
                Debug.Log("Chop"); winner = Winner.Chop;
            }
            //Straightflush
            if(playerState == Hand.Straightflush)
            {
                if(playerstraighthigh > enemystraighthigh)
                {
                    Debug.Log("Player wins"); winner = Winner.Player;
                }
                if (playerstraighthigh < enemystraighthigh)
                {
                    Debug.Log("Enemy wins"); winner = Winner.Enemy;
                }
                else
                {
                    Debug.Log("Chop"); winner = Winner.Chop;
                }
            }
            //Quads
            if(playerState == Hand.Quads)
            {
                if(playerquad > enemyquad)
                {
                    Debug.Log("Player wins"); winner = Winner.Player;
                }
                if (playerquad < enemyquad)
                {
                    Debug.Log("Enemy wins"); winner = Winner.Enemy;
                }
                if(playerquad == enemyquad)
                {
                    if(playerkicker > enemykicker)
                    {
                        Debug.Log("Player wins"); winner = Winner.Player;
                    }
                    if(playerkicker < enemykicker)
                    {
                        Debug.Log("Enemy wins"); winner = Winner.Enemy;
                    }
                    else
                    {
                        Debug.Log("Chop"); winner = Winner.Chop;
                    }
                }
            }
            //Fullhouse
            if(playerState == Hand.Fullhouse)
            {
                if(playerfh1 > enemyfh1)
                {
                    Debug.Log("Player wins"); winner = Winner.Player;
                }
                if(playerfh1 < enemyfh1)
                {
                    Debug.Log("Enemy wins"); winner = Winner.Enemy;
                }
                if(playerfh1 == enemyfh1)
                {
                    if(playerfh2 > enemyfh2)
                    {
                        Debug.Log("Player wins"); winner = Winner.Player;
                    }
                    if (playerfh2 < enemyfh2)
                    {
                        Debug.Log("Enemy wins"); winner = Winner.Enemy;
                    }
                    else
                    {
                        Debug.Log("Chop"); winner = Winner.Chop;
                    }
                }
            }
            //Flush
            if(playerState == Hand.Flush)
            {
                if(playerflushhigh > enemyflushhigh)
                {
                    Debug.Log("Player wins"); winner = Winner.Player;
                }
                if(playerflushhigh < enemyflushhigh)
                {
                    Debug.Log("Enemy wins"); winner = Winner.Enemy;
                }
                if(playerflushhigh == enemyflushhigh)
                {
                    if(playerflushkicker > enemyflushkicker)
                    {
                        Debug.Log("Player wins"); winner = Winner.Player;
                    }
                    if(playerflushkicker < enemyflushkicker)
                    {
                        Debug.Log("Enemy wins"); winner = Winner.Enemy;
                    }
                    if(playerflushkicker == enemyflushkicker)
                    {
                        Debug.Log("Chop"); winner = Winner.Chop;
                    }
                }
            }    
            //Straight
            if(playerState == Hand.Straight)
            {
                if(playerstraighthigh > enemystraighthigh)
                {
                    Debug.Log("Player wins"); winner = Winner.Player;
                }
                if (playerstraighthigh < enemystraighthigh)
                {
                    Debug.Log("Enemy wins"); winner = Winner.Enemy;
                }
                else
                {
                    Debug.Log("Chop"); winner = Winner.Chop;
                }

            }
            //Triple
            if(playerState == Hand.Triple)
            {
                if(playertrip1 > enemytrip1)
                {
                    Debug.Log("Player wins"); winner = Winner.Player;
                }
                if (playertrip1 < enemytrip1)
                {
                    Debug.Log("Player wins"); winner = Winner.Player;
                }
                if (playertrip1 == enemytrip1)
                {
                    if(playerkicker > enemykicker)
                    {
                        Debug.Log("Player wins"); winner = Winner.Player;
                    }
                    if (playerkicker < enemykicker)
                    {
                        Debug.Log("Enemy wins"); winner = Winner.Enemy;
                    }
                    if(playerkicker == enemykicker)
                    {
                        if(playerkicker2 > enemykicker2)
                        {
                            Debug.Log("Player wins"); winner = Winner.Player;
                        }
                        if(playerkicker2 < enemykicker2)
                        {
                            Debug.Log("Enemy wins"); winner = Winner.Enemy;
                        }
                        else
                        {
                            Debug.Log("Chop"); winner = Winner.Chop;
                        }
                    }
                }
            }
            //Twopair
            if(playerState == Hand.Twopair)
            {
                if(playerpair1 > enemypair1)
                {
                    Debug.Log("Player wins"); winner = Winner.Player;
                }
                if(playerpair1 < enemypair1)
                {
                    Debug.Log("Enemy wins"); winner = Winner.Enemy;
                }
                if(playerpair1 == enemypair1)
                {
                    if(playerpair2 > enemypair2)
                    {
                        Debug.Log("Player wins"); winner = Winner.Player;
                    }
                    if (playerpair2 < enemypair2)
                    {
                        Debug.Log("Enemy wins"); winner = Winner.Enemy;
                    }
                    if (playerpair2 == enemypair2)
                    {
                        if(playerkicker > enemykicker)
                        {
                            Debug.Log("Player wins"); winner = Winner.Player;
                        }
                        if (playerkicker < enemykicker)
                        {
                            Debug.Log("Enemy wins"); winner = Winner.Enemy;
                        }
                        if (playerkicker == enemykicker)
                        {
                            Debug.Log("Chop"); winner = Winner.Chop;
                        }
                    }
                }
            }
            //Pair
            if (playerState == Hand.Pair)
            {
                if (playerpair1 > enemypair1)
                {
                    Debug.Log("Player wins"); winner = Winner.Player;
                }
                if (playerpair1 < enemypair1)
                {
                    Debug.Log("Enemy wins"); winner = Winner.Enemy;
                }
                if (playerpair1 == enemypair1)
                {
                    if (playerkicker > enemykicker)
                    {
                        Debug.Log("Player wins"); winner = Winner.Player;
                    }
                    if (playerkicker < enemykicker)
                    {
                        Debug.Log("Enemy wins"); winner = Winner.Enemy;
                    }
                    if (playerkicker == enemykicker)
                    {
                        if (playerkicker2 > enemykicker2)
                        {
                            Debug.Log("Player wins"); winner = Winner.Player;
                        }
                        if (playerkicker2 < enemykicker2)
                        {
                            Debug.Log("Enemy wins"); winner = Winner.Enemy;
                        }
                        if(playerkicker2 == enemykicker2)
                        {
                            if (playerkicker3 > enemykicker3)
                            {
                                Debug.Log("Player wins"); winner = Winner.Player;
                            }
                            if (playerkicker3 < enemykicker3)
                            {
                                Debug.Log("Enemy wins"); winner = Winner.Enemy;
                            }
                            else
                            {
                                Debug.Log("Chop"); winner = Winner.Chop;
                            }
                        }
                    }
                }
            }
            //TopPair
            if (playerState == Hand.Topcard)
            {
                if (playerkicker > enemykicker)
                {
                    Debug.Log("Player wins"); winner = Winner.Player;
                }
                if (playerkicker < enemykicker)
                {
                    Debug.Log("Enemy wins"); winner = Winner.Enemy;
                }
                if (playerkicker == enemykicker)
                {
                    if (playerkicker2 > enemykicker2)
                    {
                        Debug.Log("Player wins"); winner = Winner.Player;
                    }
                    if (playerkicker2 < enemykicker2)
                    {
                        Debug.Log("Enemy wins"); winner = Winner.Enemy;
                    }
                    if (playerkicker2 == enemykicker2)
                    {
                        if (playerkicker3 > enemykicker3)
                        {
                            Debug.Log("Player wins"); winner = Winner.Player;
                        }
                        if (playerkicker3 < enemykicker3)
                        {
                            Debug.Log("Enemy wins"); winner = Winner.Enemy;
                        }
                        if (playerkicker3 == enemykicker3)
                        {
                            if (playerkicker4 > enemykicker4)
                            {
                                Debug.Log("Player wins"); winner = Winner.Player;
                            }
                            if (playerkicker4 < enemykicker4)
                            {
                                Debug.Log("Enemy wins"); winner = Winner.Enemy;
                            }
                            if (playerkicker4 == enemykicker4)
                            {
                                if (playerkicker5 > enemykicker5)
                                {
                                    Debug.Log("Player wins"); winner = Winner.Player;
                                }
                                if (playerkicker5 < enemykicker5)
                                {
                                    Debug.Log("Enemy wins"); winner = Winner.Enemy;
                                }
                                else
                                {
                                    Debug.Log("Chop"); winner = Winner.Chop;
                                }
                            }
                        }
                    }
                }
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        player = poker.playerfinalhand;


        //playervalues = playervaluesText.Select(int.Parse).ToList();

        enemy = poker.enemyfinalhand;

        if (Input.GetKeyDown(KeyCode.W))
        {
            PlayerCalculateHand();
            UpdateCardText();
            EnemyCalculateHand();
            CompareState();
        }

    }
    public void CalculateAll()
    {
        PlayerCalculateHand();
        UpdateCardText();
        EnemyCalculateHand();
        CompareState();
    }
    /*void PlayerCalculateHandTEST()
    {
        foreach(string card in player)
        {
            playersuitTEST.Add(card.Substring(0, 1));
        }
    }*/
    void PlayerCalculateHand()
    {
        //Clear prior hand
        playerhandtype = "";
        playerState = Hand.Calculating; 
        playervalues.Clear();
        playerbesthand.Clear();
        playerbestvalues.Clear();
        playerflushboard.Clear();
        playerflushvalues.Clear();
        playerkicker = 0;
        playerkicker2 = 0;
        playerkicker3 = 0;
        playerkicker4 = 0;
        playerkicker5 = 0;
        playerpair1 = 0;
        playerpair2 = 0;
        playertrip1 = 0;
        playertrip2 = 0;
        playerquad = 0;

        //Add Values as ints
        playersuits = poker.playersuits;
        playervaluesText = poker.playervalues;
        foreach (string value in playervaluesText)
        {
            if (value == "2")
            {
                playervalues.Add(2);
            }
            if (value == "3")
            {
                playervalues.Add(3);
            }
            if (value == "4")
            {
                playervalues.Add(4);
            }
            if (value == "5")
            {
                playervalues.Add(5);
            }
            if (value == "6")
            {
                playervalues.Add(6);
            }
            if (value == "7")
            {
                playervalues.Add(7);
            }
            if (value == "8")
            {
                playervalues.Add(8);
            }
            if (value == "9")
            {
                playervalues.Add(9);
            }
            if (value == "10")
            {
                playervalues.Add(10);
            }
            if (value == "J")
            {
                playervalues.Add(11);
            }
            if (value == "Q")
            {
                playervalues.Add(12);
            }
            if (value == "K")
            {
                playervalues.Add(13);
            }
            if (value == "A")
            {
                playervalues.Add(1);
                playervalues.Add(14);
            }
        }

        playervalues.Sort();

        //Royal Flush
        #region royalflush
        if (player.Contains("HA") && player.Contains("HK") && player.Contains("HQ") && player.Contains("HJ") && player.Contains("H10"))
        {
            playerhandtype = "Royal Flush";
            playerState = Hand.RoyalFlush;
            return;
        }
        if (player.Contains("DA") && player.Contains("DK") && player.Contains("DQ") && player.Contains("DJ") && player.Contains("D10"))
        {
            playerhandtype = "Royal Flush";
            playerState = Hand.RoyalFlush;
            return;
        }
        if (player.Contains("SA") && player.Contains("SK") && player.Contains("SQ") && player.Contains("SJ") && player.Contains("S10"))
        {
            playerhandtype = "Royal Flush";
            playerState = Hand.RoyalFlush;
            return;
        }
        if (player.Contains("CA") && player.Contains("CK") && player.Contains("CQ") && player.Contains("CJ") && player.Contains("C10"))
        {
            playerhandtype = "Royal Flush";
            playerState = Hand.RoyalFlush;
            return;
        }
        #endregion

        //check flush INDICATOR ONLY - HAND NOT YET DETERMINED
        #region flush
        playerflushcounter = 0;

        if (playerhandtype == "")
        {
            foreach (string suit in playersuits)
            {
                if (suit == "D")
                {
                    playerflushcounter++;
                }
            }
            if (playerflushcounter > 4)
            {
                playerflush = true;
                foreach (string card in poker.playerhand)
                {
                    if (card.Substring(0, 1) == "D")
                    {
                        playerbesthand.Add(card.Substring(card.LastIndexOf("D") + 1));
                    }
                }
                foreach (string card in player)
                {
                    if (card.Substring(0, 1) == "D")
                    {
                        playerflushboard.Add(card.Substring(card.LastIndexOf("D") + 1));
                    }
                }
            }
            if (playerflushcounter < 5)
            {
                playerflushcounter = 0;
                foreach (string suit in playersuits)
                {
                    if (suit == "H")
                    {
                        playerflushcounter++;
                    }
                }
                if (playerflushcounter > 4)
                {
                    playerflush = true;
                    foreach (string card in poker.playerhand)
                    {
                        if (card.Substring(0, 1) == "H")
                        {
                            playerbesthand.Add(card.Substring(card.LastIndexOf("H") + 1));
                        }
                    }
                    foreach (string card in player)
                    {
                        if (card.Substring(0, 1) == "H")
                        {
                            playerflushboard.Add(card.Substring(card.LastIndexOf("H") + 1));
                        }
                    }
                }
            }
             
            if (playerflushcounter < 5)
            {
                playerflushcounter = 0;

                foreach (string suit in playersuits)
                {
                    if (suit == "C")
                    {
                        playerflushcounter++;
                    }
                    
                }
                if (playerflushcounter > 4)
                {
                    playerflush = true;
                    foreach (string card in poker.playerhand)
                    {
                        if (card.Substring(0, 1) == "C")
                        {
                            playerbesthand.Add(card.Substring(card.LastIndexOf("C") + 1));
                        }
                    }
                    foreach (string card in player)
                    {
                        if (card.Substring(0, 1) == "C")
                        {
                            playerflushboard.Add(card.Substring(card.LastIndexOf("C") + 1));
                        }
                    }
                }
            }
            if (playerflushcounter < 5)
            {
                playerflushcounter = 0;

                foreach (string suit in playersuits)
                {
                    if (suit == "S")
                    {
                        playerflushcounter++;
                    }
                    
                }
                if (playerflushcounter > 4)
                {
                    playerflush = true;
                    foreach (string card in poker.playerhand)
                    {
                        if (card.Substring(0, 1) == "S")
                        {
                            playerbesthand.Add(card.Substring(card.LastIndexOf("S") + 1));
                        }
                    }
                    foreach (string card in player)
                    {
                        if (card.Substring(0, 1) == "S")
                        {
                            playerflushboard.Add(card.Substring(card.LastIndexOf("S") + 1));
                        }
                    }
                }
            }

            
            
        }
        #endregion



        //check straight INDICATOR ONLY - HAND NOT YET DETERMINED
        #region straight
        if (playerhandtype == "")
        {

            foreach (int card in playervalues)
            {
                if (playervalues.Contains(card + 1) && playervalues.Contains(card + 2) && playervalues.Contains(card + 3) && playervalues.Contains(card + 4))
                {
                    playerstraight = true;
                    playerstraighthigh = card + 4;

                }
            }
        }
        #endregion

        //check straight flush

        if (playerhandtype == "")
        {
            if (playerflush == true && playerstraight == true)
            {
                playerhandtype = "Straight Flush";
                playerState = Hand.Straightflush;
                playercard1 = playerstraighthigh;
                return;
            }
        }

        //check quads
        #region quads
        if (playerhandtype == "")
        {
            Dictionary<int, int> D = new Dictionary<int, int>();
            foreach (int card in playervalues)
            {
                if (D.TryGetValue(card, out int count))
                {
                    D[card] = count + 1;
                }
                else
                {
                    D.TryAdd(card, 1);
                }
            }
            foreach (KeyValuePair<int, int> entry in D)
            {
                Debug.Log($"Card: {entry.Key}, Count: {entry.Value}");
            }
            //to access specific num - NOTE THAT THIS MIGHT NOT WORK PROPERLY AS DICTIONARIES DONT HAVE DEFINED ORDER, CHECK LATER
            foreach (KeyValuePair<int, int> entry in D)
            {
                if (entry.Value == 2)
                {
                    playerpair2 = playerpair1;
                    playerpair1 = entry.Key;
                }
                if (entry.Value == 3)
                {
                    playertrip2 = playertrip1;
                    playertrip1 = entry.Key;
                }
                if (entry.Value == 4)
                {
                    playerquad = entry.Key;
                    playerhandtype = "Four of a Kind";
                    playercard1 = playerquad;
                    playerState = Hand.Quads;
                }
            }
            if (playerhandtype == "Four of a Kind")
            {
                foreach (int card in playervalues)
                {
                    if (card != playerquad)
                    {
                        playerkicker = card;
                    }
                }
            }
        }
        #endregion

        //check fullhouse
        if (playerhandtype == "")
        {
            if (playertrip1 > 1 && playertrip2 > 1)
            {
                playerhandtype = "Full House";
                playerState = Hand.Fullhouse;
                playerfh1 = playertrip1;
                playerfh2 = playertrip2;
                playercard1 = playerfh1;
                playercard2 = playerfh2;
            }
            if (playertrip1 > 1 && playerpair1 > 1)
            {
                playerhandtype = "Full House";
                playerState = Hand.Fullhouse;
                playerfh1 = playertrip1;
                playerfh2 = playerpair1;
                playercard1 = playerfh1;
                playercard2 = playerfh2;
            }
        }

        //check flush
        if (playerhandtype == "")
        {
            if (playerflush == true)
            {
                playerhandtype = "Flush";
                playerState = Hand.Flush;

                foreach (string value in playerbesthand)
                {
                    if (value == "2")
                    {
                        playerbestvalues.Add(2);
                    }
                    if (value == "3")
                    {
                        playerbestvalues.Add(3);
                    }
                    if (value == "4")
                    {
                        playerbestvalues.Add(4);
                    }
                    if (value == "5")
                    {
                        playerbestvalues.Add(5);
                    }
                    if (value == "6")
                    {
                        playerbestvalues.Add(6);
                    }
                    if (value == "7")
                    {
                        playerbestvalues.Add(7);
                    }
                    if (value == "8")
                    {
                        playerbestvalues.Add(8);
                    }
                    if (value == "9")
                    {
                        playerbestvalues.Add(9);
                    }
                    if (value == "10")
                    {
                        playerbestvalues.Add(10);
                    }
                    if (value == "J")
                    {
                        playerbestvalues.Add(11);
                    }
                    if (value == "Q")
                    {
                        playerbestvalues.Add(12);
                    }
                    if (value == "K")
                    {
                        playerbestvalues.Add(13);
                    }
                    if (value == "A")
                    {
                        playerbestvalues.Add(1);
                        playerbestvalues.Add(14);
                    }

                }
                playerbestvalues.Sort();
                playerflushkicker = playerbestvalues[playerbestvalues.Count - 1];

                foreach (string value in playerflushboard)
                {
                    if (value == "2")
                    {
                        playerflushvalues.Add(2);
                    }
                    if (value == "3")
                    {
                        playerflushvalues.Add(3);
                    }
                    if (value == "4")
                    {
                        playerflushvalues.Add(4);
                    }
                    if (value == "5")
                    {
                        playerflushvalues.Add(5);
                    }
                    if (value == "6")
                    {
                        playerflushvalues.Add(6);
                    }
                    if (value == "7")
                    {
                        playerflushvalues.Add(7);
                    }
                    if (value == "8")
                    {
                        playerflushvalues.Add(8);
                    }
                    if (value == "9")
                    {
                        playerflushvalues.Add(9);
                    }
                    if (value == "10")
                    {
                        playerflushvalues.Add(10);
                    }
                    if (value == "J")
                    {
                        playerflushvalues.Add(11);
                    }
                    if (value == "Q")
                    {
                        playerflushvalues.Add(12);
                    }
                    if (value == "K")
                    {
                        playerflushvalues.Add(13);
                    }
                    if (value == "A")
                    {
                        playerflushvalues.Add(1);
                        playerflushvalues.Add(14);
                    }
                }
                playerflushvalues.Sort();
                playerflushhigh = playerflushvalues[playerflushvalues.Count - 1];
                playercard1 = playerflushhigh;
            }
        }

        //check straight
        if (playerhandtype == "")
        {
            if (playerstraight == true)
            {
                playerhandtype = "Straight";
                playercard1 = playerstraighthigh;
                playerState = Hand.Straight;
            }
        }

        //check trips
        if (playerhandtype == "")
        {
            if (playertrip1 > 1)
            {
                playerhandtype = "Three of a Kind";
                playercard1 = playertrip1;
                playerState = Hand.Triple;

                foreach (int card in playervalues)
                {
                    if (card != playertrip1)
                    {
                        playerkicker2 = playerkicker;
                        playerkicker = card;
                    }
                }
            }
        }

        //check 2pair
        if (playerhandtype == "")
        {
            if (playerpair1 > 1 && playerpair2 > 1)
            {
                playerhandtype = "Two Pair";
                playercard1 = playerpair1;
                playercard2 = playerpair2;
                playerState = Hand.Twopair;
                foreach (int card in playervalues)
                {
                    if (card != playerpair1 && card != playerpair2)
                    {
                        playerkicker = card;
                    }
                }
            }
        }

        //check pair
        if (playerhandtype == "")
        {
            if (playerpair1 > 1)
            {
                playerhandtype = "Pair";
                playercard1 = playerpair1;
                playerState = Hand.Pair;
                foreach (int card in playervalues)
                {
                    if (card != playerpair1)
                    {
                        playerkicker3 = playerkicker2;
                        playerkicker2 = playerkicker;
                        playerkicker = card;
                    }
                }
            }
        }

        //check topcard with kickers
        if (playerhandtype == "")
        {
            playerhandtype = "Top Card";
            playerState = Hand.Topcard;
            foreach (int card in playervalues)
            {
                playerkicker5 = playerkicker4;
                playerkicker4 = playerkicker3;
                playerkicker3 = playerkicker2;
                playerkicker2 = playerkicker;
                playerkicker = card;
            }
            playercard1 = playerkicker;
        }
    }

    void EnemyCalculateHand()
    {
        //Clear prior hand
        enemyhandtype = "";
        enemyState = Hand.Calculating;
        enemyvalues.Clear();
        enemybesthand.Clear();
        enemybestvalues.Clear();
        enemyflushboard.Clear();
        enemyflushvalues.Clear();
        enemykicker = 0;
        enemykicker2 = 0;
        enemykicker3 = 0;
        enemykicker4 = 0;
        enemykicker5 = 0;
        enemypair1 = 0;
        enemypair2 = 0;
        enemytrip1 = 0;
        enemytrip2 = 0;
        enemyquad = 0;

        //Add Values as ints
        enemysuits = poker.enemysuits;
        enemyvaluesText = poker.enemyvalues;
        foreach (string value in enemyvaluesText)
        {
            if (value == "2")
            {
                enemyvalues.Add(2);
            }
            if (value == "3")
            {
                enemyvalues.Add(3);
            }
            if (value == "4")
            {
                enemyvalues.Add(4);
            }
            if (value == "5")
            {
                enemyvalues.Add(5);
            }
            if (value == "6")
            {
                enemyvalues.Add(6);
            }
            if (value == "7")
            {
                enemyvalues.Add(7);
            }
            if (value == "8")
            {
                enemyvalues.Add(8);
            }
            if (value == "9")
            {
                enemyvalues.Add(9);
            }
            if (value == "10")
            {
                enemyvalues.Add(10);
            }
            if (value == "J")
            {
                enemyvalues.Add(11);
            }
            if (value == "Q")
            {
                enemyvalues.Add(12);
            }
            if (value == "K")
            {
                enemyvalues.Add(13);
            }
            if (value == "A")
            {
                enemyvalues.Add(1);
                enemyvalues.Add(14);
            }
        }

        enemyvalues.Sort();

        //Royal Flush
        #region royalflush
        if (enemy.Contains("HA") && enemy.Contains("HK") && enemy.Contains("HQ") && enemy.Contains("HJ") && enemy.Contains("H10"))
        {
            enemyhandtype = "Royal Flush";
            enemyState = Hand.RoyalFlush;
            return;
        }
        if (enemy.Contains("DA") && enemy.Contains("DK") && enemy.Contains("DQ") && enemy.Contains("DJ") && enemy.Contains("D10"))
        {
            enemyhandtype = "Royal Flush";
            enemyState = Hand.RoyalFlush;
            return;
        }
        if (enemy.Contains("SA") && enemy.Contains("SK") && enemy.Contains("SQ") && enemy.Contains("SJ") && enemy.Contains("S10"))
        {
            enemyhandtype = "Royal Flush";
            enemyState = Hand.RoyalFlush;
            return;
        }
        if (enemy.Contains("CA") && enemy.Contains("CK") && enemy.Contains("CQ") && enemy.Contains("CJ") && enemy.Contains("C10"))
        {
            enemyhandtype = "Royal Flush";
            enemyState = Hand.RoyalFlush;
            return;
        }
        #endregion

        //check flush INDICATOR ONLY - HAND NOT YET DETERMINED
        #region flush
        enemyflushcounter = 0;

        if (enemyhandtype == "")
        {
            foreach (string suit in enemysuits)
            {
                if (suit == "D")
                {
                    enemyflushcounter++;
                }
            }
            if (enemyflushcounter > 4)
            {
                enemyflush = true;
                foreach (string card in poker.enemyhand)
                {
                    if (card.Substring(0, 1) == "D")
                    {
                        enemybesthand.Add(card.Substring(card.LastIndexOf("D") + 1));
                    }
                }
                foreach (string card in enemy)
                {
                    if (card.Substring(0, 1) == "D")
                    {
                        enemyflushboard.Add(card.Substring(card.LastIndexOf("D") + 1));
                    }
                }
            }
            if (enemyflushcounter < 5)
            {
                enemyflushcounter = 0;
                foreach (string suit in enemysuits)
                {
                    if (suit == "H")
                    {
                        enemyflushcounter++;
                    }
                }
                if (enemyflushcounter > 4)
                {
                    enemyflush = true;
                    foreach (string card in poker.enemyhand)
                    {
                        if (card.Substring(0, 1) == "H")
                        {
                            enemybesthand.Add(card.Substring(card.LastIndexOf("H") + 1));
                        }
                    }
                    foreach (string card in enemy)
                    {
                        if (card.Substring(0, 1) == "H")
                        {
                            enemyflushboard.Add(card.Substring(card.LastIndexOf("H") + 1));
                        }
                    }
                }
            }

            if (enemyflushcounter < 5)
            {
                enemyflushcounter = 0;

                foreach (string suit in enemysuits)
                {
                    if (suit == "C")
                    {
                        enemyflushcounter++;
                    }

                }
                if (enemyflushcounter > 4)
                {
                    enemyflush = true;
                    foreach (string card in poker.enemyhand)
                    {
                        if (card.Substring(0, 1) == "C")
                        {
                            enemybesthand.Add(card.Substring(card.LastIndexOf("C") + 1));
                        }
                    }
                    foreach (string card in enemy)
                    {
                        if (card.Substring(0, 1) == "C")
                        {
                            enemyflushboard.Add(card.Substring(card.LastIndexOf("C") + 1));
                        }
                    }
                }
            }
            if (enemyflushcounter < 5)
            {
                enemyflushcounter = 0;

                foreach (string suit in enemysuits)
                {
                    if (suit == "S")
                    {
                        enemyflushcounter++;
                    }

                }
                if (enemyflushcounter > 4)
                {
                    enemyflush = true;
                    foreach (string card in poker.enemyhand)
                    {
                        if (card.Substring(0, 1) == "S")
                        {
                            enemybesthand.Add(card.Substring(card.LastIndexOf("S") + 1));
                        }
                    }
                    foreach (string card in enemy)
                    {
                        if (card.Substring(0, 1) == "S")
                        {
                            enemyflushboard.Add(card.Substring(card.LastIndexOf("S") + 1));
                        }
                    }
                }
            }



        }
        #endregion



        //check straight INDICATOR ONLY - HAND NOT YET DETERMINED
        #region straight
        if (enemyhandtype == "")
        {

            foreach (int card in enemyvalues)
            {
                if (enemyvalues.Contains(card + 1) && enemyvalues.Contains(card + 2) && enemyvalues.Contains(card + 3) && enemyvalues.Contains(card + 4))
                {
                    enemystraight = true;
                    enemystraighthigh = card + 4;

                }
            }
        }
        #endregion

        //check straight flush

        if (enemyhandtype == "")
        {
            if (enemyflush == true && enemystraight == true)
            {
                enemyhandtype = "Straight Flush";
                enemyState = Hand.Straightflush;
                return;
            }
        }

        //check quads
        #region quads
        if (enemyhandtype == "")
        {
            Dictionary<int, int> D = new Dictionary<int, int>();
            foreach (int card in enemyvalues)
            {
                if (D.TryGetValue(card, out int count))
                {
                    D[card] = count + 1;
                }
                else
                {
                    D.TryAdd(card, 1);
                }
            }
            foreach (KeyValuePair<int, int> entry in D)
            {
                Debug.Log($"Card: {entry.Key}, Count: {entry.Value}");
            }
            //to access specific num - NOTE THAT THIS MIGHT NOT WORK PROPERLY AS DICTIONARIES DONT HAVE DEFINED ORDER, CHECK LATER
            foreach (KeyValuePair<int, int> entry in D)
            {
                if (entry.Value == 2)
                {
                    enemypair2 = enemypair1;
                    enemypair1 = entry.Key;
                }
                if (entry.Value == 3)
                {
                    enemytrip2 = enemytrip1;
                    enemytrip1 = entry.Key;
                }
                if (entry.Value == 4)
                {
                    enemyquad = entry.Key;
                    enemyhandtype = "Four of a Kind";
                    enemyState = Hand.Quads;
                }
            }
            if (enemyhandtype == "Four of a Kind")
            {
                foreach (int card in enemyvalues)
                {
                    if (card != enemyquad)
                    {
                        enemykicker = card;
                    }
                }
            }
        }
        #endregion

        //check fullhouse
        if (enemyhandtype == "")
        {
            if (enemytrip1 > 1 && enemytrip2 > 1)
            {
                enemyhandtype = "Full House";
                enemyState = Hand.Fullhouse;
                enemyfh1 = enemytrip1;
                enemyfh2 = enemytrip2;
            }
            if (enemytrip1 > 1 && enemypair1 > 1)
            {
                enemyhandtype = "Full House";
                enemyState = Hand.Fullhouse;
                enemyfh1 = enemytrip1;
                enemyfh2 = enemypair1;
            }
        }

        //check flush
        if (enemyhandtype == "")
        {
            if (enemyflush == true)
            {
                enemyhandtype = "Flush";
                enemyState = Hand.Flush;

                foreach (string value in enemybesthand)
                {
                    if (value == "2")
                    {
                        enemybestvalues.Add(2);
                    }
                    if (value == "3")
                    {
                        enemybestvalues.Add(3);
                    }
                    if (value == "4")
                    {
                        enemybestvalues.Add(4);
                    }
                    if (value == "5")
                    {
                        enemybestvalues.Add(5);
                    }
                    if (value == "6")
                    {
                        enemybestvalues.Add(6);
                    }
                    if (value == "7")
                    {
                        enemybestvalues.Add(7);
                    }
                    if (value == "8")
                    {
                        enemybestvalues.Add(8);
                    }
                    if (value == "9")
                    {
                        enemybestvalues.Add(9);
                    }
                    if (value == "10")
                    {
                        enemybestvalues.Add(10);
                    }
                    if (value == "J")
                    {
                        enemybestvalues.Add(11);
                    }
                    if (value == "Q")
                    {
                        enemybestvalues.Add(12);
                    }
                    if (value == "K")
                    {
                        enemybestvalues.Add(13);
                    }
                    if (value == "A")
                    {
                        enemybestvalues.Add(1);
                        enemybestvalues.Add(14);
                    }

                }
                enemybestvalues.Sort();
                enemyflushkicker = enemybestvalues[enemybestvalues.Count - 1];

                foreach (string value in enemyflushboard)
                {
                    if (value == "2")
                    {
                        enemyflushvalues.Add(2);
                    }
                    if (value == "3")
                    {
                        enemyflushvalues.Add(3);
                    }
                    if (value == "4")
                    {
                        enemyflushvalues.Add(4);
                    }
                    if (value == "5")
                    {
                        enemyflushvalues.Add(5);
                    }
                    if (value == "6")
                    {
                        enemyflushvalues.Add(6);
                    }
                    if (value == "7")
                    {
                        enemyflushvalues.Add(7);
                    }
                    if (value == "8")
                    {
                        enemyflushvalues.Add(8);
                    }
                    if (value == "9")
                    {
                        enemyflushvalues.Add(9);
                    }
                    if (value == "10")
                    {
                        enemyflushvalues.Add(10);
                    }
                    if (value == "J")
                    {
                        enemyflushvalues.Add(11);
                    }
                    if (value == "Q")
                    {
                        enemyflushvalues.Add(12);
                    }
                    if (value == "K")
                    {
                        enemyflushvalues.Add(13);
                    }
                    if (value == "A")
                    {
                        enemyflushvalues.Add(1);
                        enemyflushvalues.Add(14);
                    }
                }
                enemyflushvalues.Sort();
                enemyflushhigh = enemyflushvalues[enemyflushvalues.Count - 1];
            }
        }

        //check straight
        if (enemyhandtype == "")
        {
            if (enemystraight == true)
            {
                enemyhandtype = "Straight";
                enemyState = Hand.Straight;
            }
        }

        //check trips
        if (enemyhandtype == "")
        {
            if (enemytrip1 > 1)
            {
                enemyhandtype = "Three of a Kind";
                enemyState = Hand.Triple;

                foreach (int card in enemyvalues)
                {
                    if (card != enemytrip1)
                    {
                        enemykicker2 = enemykicker;
                        enemykicker = card;
                    }
                }
            }
        }

        //check 2pair
        if (enemyhandtype == "")
        {
            if (enemypair1 > 1 && enemypair2 > 1)
            {
                enemyhandtype = "Two Pair";
                enemyState = Hand.Twopair;
                foreach (int card in enemyvalues)
                {
                    if (card != enemypair1 && card != enemypair2)
                    {
                        enemykicker = card;
                    }
                }
            }
        }

        //check pair
        if (enemyhandtype == "")
        {
            if (enemypair1 > 1)
            {
                enemyhandtype = "Pair";
                enemyState = Hand.Pair;
                foreach (int card in enemyvalues)
                {
                    if (card != enemypair1)
                    {
                        enemykicker3 = enemykicker2;
                        enemykicker2 = enemykicker;
                        enemykicker = card;
                    }
                }
            }
        }

        //check topcard with kickers
        if (enemyhandtype == "")
        {
            enemyhandtype = "Top Card";
            enemyState = Hand.Topcard;
            foreach (int card in enemyvalues)
            {
                enemykicker5 = enemykicker4;
                enemykicker4 = enemykicker3;
                enemykicker3 = enemykicker2;
                enemykicker2 = enemykicker;
                enemykicker = card;
            }

        }
    }
}
