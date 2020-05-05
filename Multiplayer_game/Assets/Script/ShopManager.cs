using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager : MonoBehaviour
{

    public static bool chameleon = false, angrypig = false, turtle = false;
    private int chameleonP = 50, angrypigP = 75, turtleP = 105;
    public bool isSucced = false;

    public bool BuyChameleon()
    {
        if(Player.totalCoin >= chameleonP)
        {
            chameleon = true; //satın alındı. 
            Player._chameleon = true;
            Player._slime = false;
            Player._turtle = false;
            Player._angryPig = false;
            Player._playerScore-= chameleonP;
            isSucced = true;
            return isSucced;

        }
        else
        {
            Debug.Log("Not enough money");
            return isSucced;
        }
    }

    

    public bool BuyTurtle()
    {
        if(Player.totalCoin >= turtleP)
        {
            turtle = true;
            Player._turtle = true;
            Player._slime = false;
            Player._chameleon = false;
            Player._angryPig = false;
            Player._playerScore -= turtleP;
            isSucced = true;
            return isSucced;

        }
        else
        {
            Debug.Log("Not enoght money");
            return isSucced;
        }

    }

    public bool BuyAngryPig()
    {
        if (Player.totalCoin >= angrypigP)
        {
            angrypig = true;
            Player._turtle = false;
            Player._slime = false;
            Player._chameleon = false;
            Player._angryPig = true;
            Player._playerScore -= angrypigP;
            isSucced = true;
            return isSucced;

        }
        else
        {
            Debug.Log("Not enoght money");
            return isSucced;
        }

    }

}
