using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class ScorePanel : MonoBehaviour
{
    public TextMeshProUGUI monsterkilltxt;
    public TextMeshProUGUI timetxt;
    public TextMeshProUGUI damgetxt;
    public Transform gamestartUI;
    public Transform gameoverUI;
    public Transform gamescoreUI;
    public Button retryBTN;
    public Button mainmenuBTN;
    public Button quitBTN;

    public GameManeger gameManeger;

    int kill;
    float time;
    int damge;
    bool clicked;

    IEnumerator Score()
    {
        retryBTN.gameObject.SetActive(false);
        mainmenuBTN.gameObject.SetActive(false);
        quitBTN.gameObject.SetActive(false);
        gameoverUI.gameObject.SetActive(true);
        yield return new WaitForSeconds(3f);
        gameoverUI.gameObject.SetActive(false);
        clicked = false;
        gamescoreUI.gameObject.SetActive(true);

        for (kill = 0; kill < gameManeger.MONSTERSKILL; kill++)
        {
            kill++;
            monsterkilltxt.SetText(kill + 1 +"");
            yield return new WaitForSeconds(0.03f);
        }

        float timesurvie = 1800 - gameManeger.timer.timeRemaining;
        for (time = 0; time < timesurvie; time++)
        {
            int minutes = Mathf.FloorToInt(time / 60);
            int seconds = Mathf.FloorToInt(time % 60);
            timetxt.SetText(minutes + " : " + seconds);
            yield return new WaitForSeconds(0.03f);
        }

        for (damge = 0; damge < gameManeger.DAMGEDEAL; damge++)
        {
            damge++;
            damgetxt.SetText(damge + 1 + "");
            yield return new WaitForSeconds(0.03f);
        }

        yield return new WaitForSeconds(0.3f);
        retryBTN.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        mainmenuBTN.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        quitBTN.gameObject.SetActive(true);
        yield return new WaitUntil(() => clicked == true);
        gamescoreUI.gameObject.SetActive(false);
        yield return null;
    }

    public void retryClicked()
    {
        clicked = true;
        gameManeger.RestartGame();
    }
    public void mainmenuClicked()
    {
        clicked = true;
    }

    public void quitClicked()
    {
        clicked = true;
    }

}
