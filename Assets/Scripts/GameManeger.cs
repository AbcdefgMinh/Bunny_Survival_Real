using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManeger : MonoBehaviour
{

    public static int MONSTERSKILL;
    public static int DAMGEDEAL;

    public Transform loadingscene;
    public Animator loadingAnim;

    public Timer timer;
    public Player player;
    public ScorePanel scorepanel;

    public static List<Monster> monsters;
    public static bool pause = false;

    int x1 = -25;
    int x2 = 30;
    int y1 = 23;
    int y2 = -12;

    bool spawning = true;
    bool maxMonster = false;

    public void Awake()
    {
        gamePause(true);
    }
    void Start()
    {
        monsters = new List<Monster>();
        StartCoroutine("GameStart");

    }
    
    public void Update()
    {
        if(pause) return;
        Debug.Log(monsters.Count);
        if (monsters.Count >= 100)
        {
            maxMonster = true;
        }
        else
        {
            maxMonster = false;
        }

        switch ((int)timer.timeRemaining)
        {
            case 1799:
                if (spawning == false) break;
                spawning = false;
                StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(new Vector2(25, 0)), 30, Monster.monsterType.MON1));
                break;
            case 1788: spawning = true; break;
            //////////////////////////////////////////////////////////
            case 1780:
                if (spawning == false) break;
                spawning = false;

                StartCoroutine(WaitAndDo(3f, () => { 
                    StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 5, Monster.monsterType.MON1));
                    StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 5, Monster.monsterType.MON1));
                    StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 5, Monster.monsterType.MON1));
                    StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 5, Monster.monsterType.MON1));
                }));
                StartCoroutine(WaitAndDo(10f, () => {
                    StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 5, Monster.monsterType.MON2));
                    StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 5, Monster.monsterType.MON2));
                    StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 5, Monster.monsterType.MON2));
                }));
                StartCoroutine(WaitAndDo(15f, () => { 
                    StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 5, Monster.monsterType.MON2)); 
                    StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 5, Monster.monsterType.MON2));
                    StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 5, Monster.monsterType.MON2));
                }));

                StartCoroutine(WaitAndDo(3f, () => { StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 30, Monster.monsterType.MON3)); }));
 
                
                break;
            case 1778: spawning = true; break;
            //////////////////////////////////////////////////////////
            case 1770:
                if (spawning == false) break;
                spawning = false;



                break;
            case 1768: spawning = true; break;
        }
    }

    IEnumerator GameStart()
    {
        loadingscene.gameObject.SetActive(true);
        loadingAnim.SetTrigger("done");
        yield return new WaitForSeconds(2.5f);
        MONSTERSKILL = 0;
        DAMGEDEAL = 0;     
        scorepanel.gamestartUI.gameObject.SetActive(true);
        yield return new WaitForSeconds(3f);
        scorepanel.gamestartUI.gameObject.SetActive(false);
        gamePause(false);
        timer.timerIsRunning = true;
        ItemController.spawnItem(new Vector2 (0,-1), Item.itemType.LUCKYBOX);
        yield return null;
    }

    IEnumerator RestartGame()
    {
        loadingAnim.SetTrigger("in");
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(1);
        yield return null;  
    }

    IEnumerator MainMenu()
    {
        loadingAnim.SetTrigger("in");
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(0);
        yield return null;
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

    IEnumerator CreateWave(Transform door, int amount, Monster.monsterType monsterType)
    {
        yield return new WaitForSeconds(3f);
        for (int i = 0; i < amount; i++)
        {
            yield return new WaitWhile(() => maxMonster != false);

            MonsterSpawn.spawnMonster(door.position , monsterType);
            yield return new WaitForSeconds(0.1f);
        }

        Destroy(door.gameObject);
        yield return null;
    }

    IEnumerator WaitAndDo(float time, System.Action action)
    {
        yield return new WaitForSeconds(time);
        action();
    }

    public Vector2 getRamdomPos()
    {
        return new Vector2(Random.Range(x1, x2), Random.Range(y2, y1));
    }
   
}
