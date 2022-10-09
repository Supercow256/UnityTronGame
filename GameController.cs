using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject Player1;
    public GameObject Player2;
    public GameObject Player3;
    public GameObject Player4;

    // Start is called before the first frame update
    void Start()
    {
    }
    void Update()
    {
        if(GlobalVars.NumOfPlayers == 2)
        {
            Destroy(Player3);
            Destroy(Player4);
        }
        else if (GlobalVars.NumOfPlayers == 3)
        {
            Destroy(Player4);
        }

    }
}
