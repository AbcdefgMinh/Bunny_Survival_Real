using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManeger : MonoBehaviour
{

    public int MONSTERSKILL = 180;
    public int DAMGEDEAL = 200;

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
        phase = phaseType.phase1;
        monsters = new List<Monster>();

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

    public void StartGame()
    {

    }

    public void RestartGame()
    {

    }

    public void EndGame()
    {

    }

    public void gamePause(bool x)
    {
        pause = x;
        player.controller.enable = !x;
        timer.timerIsRunning = !x;
    }
  
   
}
