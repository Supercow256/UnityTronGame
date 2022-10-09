using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalVars : MonoBehaviour
{
    public static Color Player1Color = Color.red;
    public static Color Player2Color = Color.green;
    public static Color Player3Color = Color.blue;
    public static Color Player4Color = Color.magenta;
    public static float keepTime;

    public static Vector3 Player1Start = new Vector3(-20, 9, 0);
    public static Vector3 Player2Start = new Vector3(20, 9, 0);
    public static Vector3 Player3Start = new Vector3(-20, -9, 0);
    public static Vector3 Player4Start = new Vector3(-20, 9, 0);

    public static int NumOfPlayers = 2;

    public static bool Player1IsAlive = true;
    public static bool Player2IsAlive = true;
    public static bool Player3IsAlive = true;
    public static bool Player4IsAlive = true;

    public static int Player1Wins = 0;
    public static int Player2Wins = 0;
    public static int Player3Wins = 0;
    public static int Player4Wins = 0;

}
