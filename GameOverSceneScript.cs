using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameOverSceneScript : MonoBehaviour
{
    public Text winnerText;
    public Text redWins;
    public Text greenWins;
    public Text blueWins;
    public Text magentaWins;

    // Start is called before the first frame update
    void Start()
    {
       if(GlobalVars.NumOfPlayers == 2)
        {
            if(GlobalVars.Player1IsAlive)
            {
                winnerText.text = "The Winner Is Red";
                GlobalVars.Player1Wins++;
            }
            else if (GlobalVars.Player2IsAlive)
            {
                winnerText.text = "The Winner Is Green";
                GlobalVars.Player2Wins++;
            }
        }
        else if (GlobalVars.NumOfPlayers == 3)
        {
            if (GlobalVars.Player1IsAlive)
            {
                winnerText.text = "The Winner Is Red";
                GlobalVars.Player1Wins++;
            }
            else if (GlobalVars.Player2IsAlive)
            {
                winnerText.text = "The Winner Is Green";
                GlobalVars.Player2Wins++;
            }
            else if (GlobalVars.Player3IsAlive)
            {
                winnerText.text = "The Winner Is Blue";
                GlobalVars.Player3Wins++;
            }
        }
       else if (GlobalVars.NumOfPlayers == 4)
        {
            if (GlobalVars.Player1IsAlive)
            {
                winnerText.text = "The Winner Is Red";
                GlobalVars.Player1Wins++;
            }
            else if (GlobalVars.Player2IsAlive)
            {
                winnerText.text = "The Winner Is Green";
                GlobalVars.Player2Wins++;
            }
            else if (GlobalVars.Player3IsAlive)
            {
                winnerText.text = "The Winner Is Blue";
                GlobalVars.Player3Wins++;
            }
            else if (GlobalVars.Player4IsAlive)
            {
                winnerText.text = "The Winner Is Magenta";
                GlobalVars.Player4Wins++;
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        
        redWins.text = "Red has won " + GlobalVars.Player1Wins + " times";
        greenWins.text = "Green has won " + GlobalVars.Player2Wins + " times";
        if (GlobalVars.NumOfPlayers == 3)
            blueWins.text = "Blue has won " + GlobalVars.Player3Wins + " times";
        else
            blueWins.text = "";
        if (GlobalVars.NumOfPlayers == 4)
            magentaWins.text = "Magenta has won " + GlobalVars.Player4Wins + " times";
        else
            magentaWins.text = "";
        
    }
}
