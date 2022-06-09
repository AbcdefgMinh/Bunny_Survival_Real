using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Menu : MonoBehaviour
{
    public GameManeger gameManeger;
    public Transform panel;
    bool pause = false;

    public static Menu Instance { get; private set; }
    public void Awake()
    {
        Instance = this;
    }
    public void PauseGame()
    {
        pause = !pause;
        panel.gameObject.SetActive(pause);
        gameManeger.gamePause(pause);
    }

    public void continueClicked()
    {
        pause = !pause;
        panel.gameObject.SetActive(pause);
        gameManeger.gamePause(pause);
    }

    public void mainmenuClicked()
    {
        gameManeger.StartCoroutine("MainMenu");
    }

    public void quitClicked()
    {
        Application.Quit();
    }
}
