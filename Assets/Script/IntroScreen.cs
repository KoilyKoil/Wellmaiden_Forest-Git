using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroScreen : MonoBehaviour
{
    public GameObject mainGame;
    public GameObject menuScreen;

    public void GameStart()
    {
        mainGame.SetActive(true);
        menuScreen.SetActive(false);
    }

    public void GameOver()
    {
        
        mainGame.SetActive(false);
        menuScreen.SetActive(true);
    }
}
