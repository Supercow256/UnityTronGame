using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingsScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //SceneManager.LoadScene("StartScene");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void NumOfPlayers(int players)
    {
        GlobalVars.NumOfPlayers = players + 2;
    }

    public void LoadMainGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void LoadStartScreen()
    {
        SceneManager.LoadScene("StartScene");
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
