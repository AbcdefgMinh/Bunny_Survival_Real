using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManeger : MonoBehaviour
{
    public Player player;
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
    phaseType phase;
    public Transform door;
    public Timer timer;
    public List<Monster> monsters;

    void Start()
    {
        phase = phaseType.phase1;
        monsters = new List<Monster>();
    }
    
    public void Update()
    {
        if (phase == phaseType.phase1)
        {
            MonsterSpawn.spawnMonster(door.transform.position, Monster.monsterType.MON1);
        }
        if (timer.timeRemaining < 1798f)
        {
            phase = phaseType.phase2;
        }
    }
    
    public void SpawnMonster()
    {

    }
  
   
}
