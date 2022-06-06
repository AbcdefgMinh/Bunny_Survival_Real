using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManeger : MonoBehaviour
{

    public int MONSTERSKILL;
    public int DAMGEDEAL;

    public enum phaseType
    {
        phase1,
        phase2,
        phase3,
        phase4,
        phase5,
        phase6,
        phase7,
        phase8
    }
    public phaseType phase;

    public Timer timer;
    public Player player;
    public ScorePanel scorepanel;


    public Transform door;
    public List<Monster> monsters;
    public bool pause = false;

    void Start()
    {
        monsters = new List<Monster>();
       //StartCoroutine("GameStart");

    }
    
    public void Update()
    {
        if(pause) return;

        /* if (phase == phaseType.phase1)
         {
             MonsterSpawn.spawnMonster(door.transform.position, Monster.monsterType.MON1);
         }
         if (timer.timeRemaining < 1798f)
         {
             phase = phaseType.phase2;
         }*/

    }
    
    public void SpawnMonster()
    {

    }

    IEnumerator GameStart()
    {
        gamePause(true);
        timer.timeRemaining = 1800;
        MONSTERSKILL = 0;
        DAMGEDEAL = 0;     
        phase = phaseType.phase1;
        scorepanel.gamestartUI.gameObject.SetActive(true);
        yield return new WaitForSeconds(2.5f);
        scorepanel.gamestartUI.gameObject.SetActive(false);
        gamePause(false);
        yield return null;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void EndGame()
    {
        gamePause(true);
        scorepanel.StartCoroutine("Score");
    }

    public void gamePause(bool x)
    {
        pause = x;
        player.controller.enable = !x;
        timer.timerIsRunning = !x;
    }
  
   
}
