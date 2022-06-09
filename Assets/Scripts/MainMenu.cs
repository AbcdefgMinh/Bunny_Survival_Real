using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public Transform mainpanel;
    public Transform tutorialpanel;
    public Transform loadingscreen;
    public Transform text;

    public GameObject panel1;
    public GameObject panel2;
    public GameObject panel3;

    List<GameObject> panellist;
    int current = 0;

    public TextMeshProUGUI count;

    public Button playBTN;
    public Button tutorialBTN;
    public Button quitBTN;

    public Animator movie;
    public Animator LoadingScreen;
    public Animator mainmenu;


    void Awake()
    {
        loadingscreen.gameObject.SetActive(true);
    }
    void Start()
    {
        panellist = new List<GameObject>();
        StartCoroutine("GameBegin");
        playBTN.gameObject.SetActive(false);
        tutorialBTN.gameObject.SetActive(false);
        quitBTN.gameObject.SetActive(false);
        panellist.Add(panel1);
        panellist.Add(panel2);
        panellist.Add(panel3);

    }
    IEnumerator GameBegin()
    {
        yield return new WaitForSeconds(2f);
        LoadingScreen.SetTrigger("done");
        yield return new WaitForSeconds(1f);
        mainmenu.SetTrigger("start");
        yield return new WaitForSeconds(4f);
        playBTN.gameObject.SetActive(true);
        tutorialBTN.gameObject.SetActive(true);
        quitBTN.gameObject.SetActive(true);  
        yield return null;
    }

    IEnumerator PlayMovie()
    {
        mainmenu.SetTrigger("fade");
        text.gameObject.SetActive(false);
        yield return new WaitForSeconds(1.5f);
        movie.SetTrigger("play");
        yield return new WaitForSeconds(6f);
        LoadingScreen.SetTrigger("in");
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(1);
        yield return null;
    }

    public void onPlayClicked()
    {
        StartCoroutine("PlayMovie");
    }
    public void onTutorialClicked()
    {
        panellist[current].SetActive(false);
        current = 0;
        panellist[current].SetActive(true);
        count.SetText(panellist.Count + " / " + (current + 1));
        tutorialpanel.gameObject.SetActive(true);
    }
    public void onQuitClicked()
    {
        Application.Quit();
    }

    public void onNextClicked()
    {
        panellist[current].SetActive(false);
        current++;
        if (current > panellist.Count -1) current = 0;
        count.SetText(panellist.Count + " / " + (current + 1));
        panellist[current].SetActive(true);

    }

    public void onBackClicked()
    {
        panellist[current].SetActive(false);
        current--;
        if (current < 0) current = panellist.Count - 1;
        count.SetText(panellist.Count + " / " + (current + 1));
        panellist[current].SetActive(true);
    }

    public void onExitClicked()
    {
        tutorialpanel.gameObject.SetActive(false);
    }
}
