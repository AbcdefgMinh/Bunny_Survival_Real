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
        if (monsters.Count >= 200)
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
                StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(new Vector2(25, 0)), 50, Monster.monsterType.MON1));
                break;
            case 1788: spawning = true; break;
            //////////////////////////////////////////////////////////
            case 1780:
                if (spawning == false) break;
                spawning = false;
                StartCoroutine(WaitAndDo(30f, () => { StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 5, Monster.monsterType.MON4)); }));
                StartCoroutine(WaitAndDo(3f, () => { 
                    StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 10, Monster.monsterType.MON1));
                    StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 10, Monster.monsterType.MON1));
                    StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 10, Monster.monsterType.MON1));
                }));
                StartCoroutine(WaitAndDo(10f, () => {
                    StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 10, Monster.monsterType.MON2));
                    StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 10, Monster.monsterType.MON2));
                    StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 10, Monster.monsterType.MON2));
                }));
                StartCoroutine(WaitAndDo(15f, () => { 
                    StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 10, Monster.monsterType.MON2)); 
                    StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 10, Monster.monsterType.MON2));
                    StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 10, Monster.monsterType.MON2));
                }));

                StartCoroutine(WaitAndDo(3f, () => { StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 20, Monster.monsterType.MON2)); }));
                StartCoroutine(WaitAndDo(3f, () => { StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 20, Monster.monsterType.MON3)); }));


                break;
            case 1778: spawning = true; break;
            //////////////////////////////////////////////////////////
            case 1750:
                if (spawning == false) break;
                spawning = false;
                StartCoroutine(WaitAndDo(30f, () => { StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 10, Monster.monsterType.MON4)); }));

                StartCoroutine(WaitAndDo(3f, () => {
                    StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 10, Monster.monsterType.MON1));
                    StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 10, Monster.monsterType.MON1));
                    StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 10, Monster.monsterType.MON1));
                }));
                StartCoroutine(WaitAndDo(10f, () => {
                    StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 10, Monster.monsterType.MON2));
                    StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 10, Monster.monsterType.MON2));
                    StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 10, Monster.monsterType.MON2));
                }));
                StartCoroutine(WaitAndDo(15f, () => {
                    StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 10, Monster.monsterType.MON3));
                    StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 10, Monster.monsterType.MON3));
                    StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 10, Monster.monsterType.MON3));
                }));

                StartCoroutine(WaitAndDo(3f, () => { StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 20, Monster.monsterType.MON1)); }));
                StartCoroutine(WaitAndDo(5f, () => { StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()),40, Monster.monsterType.MON2)); }));
                StartCoroutine(WaitAndDo(7f, () => { StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()),40, Monster.monsterType.MON3)); }));


                break;
            case 1748: spawning = true; break;
            /////////////
            ///
            //////////////////////////////////////////////////////////
            case 1700:
                if (spawning == false) break;
                spawning = false;
                StartCoroutine(WaitAndDo(30f, () => { StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 10, Monster.monsterType.MON4)); }));

                StartCoroutine(WaitAndDo(3f, () => {
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
                    StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 5, Monster.monsterType.MON3));
                    StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 5, Monster.monsterType.MON3));
                    StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 5, Monster.monsterType.MON3));
                }));

                StartCoroutine(WaitAndDo(3f, () => { StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()),40, Monster.monsterType.MON1)); }));
                StartCoroutine(WaitAndDo(5f, () => { StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()),40, Monster.monsterType.MON2)); }));
                StartCoroutine(WaitAndDo(7f, () => { StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()),40, Monster.monsterType.MON3)); }));


                break;
            case 1698: spawning = true; break;
            /////////////
            /// //////////////////////////////////////////////////////////
            case 1650:
                if (spawning == false) break;
                spawning = false;
                StartCoroutine(WaitAndDo(30f, () => { StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 10, Monster.monsterType.MON4)); }));

                StartCoroutine(WaitAndDo(3f, () => {
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
                    StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 5, Monster.monsterType.MON3));
                    StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 5, Monster.monsterType.MON3));
                    StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 5, Monster.monsterType.MON3));
                }));

                StartCoroutine(WaitAndDo(3f, () => { StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()),40, Monster.monsterType.MON1)); }));
                StartCoroutine(WaitAndDo(5f, () => { StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()),40, Monster.monsterType.MON2)); }));
                StartCoroutine(WaitAndDo(7f, () => { StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()),40, Monster.monsterType.MON3)); }));


                break;
            case 1648: spawning = true; break;
            /////////////
            /// //////////////////////////////////////////////////////////
            case 1600:
                if (spawning == false) break;
                spawning = false;
                StartCoroutine(WaitAndDo(30f, () => { StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 10, Monster.monsterType.MON4)); }));

                StartCoroutine(WaitAndDo(3f, () => {
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
                    StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 5, Monster.monsterType.MON3));
                    StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 5, Monster.monsterType.MON3));
                    StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 5, Monster.monsterType.MON3));
                }));

                StartCoroutine(WaitAndDo(3f, () => { StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()),40, Monster.monsterType.MON1)); }));
                StartCoroutine(WaitAndDo(5f, () => { StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()),40, Monster.monsterType.MON2)); }));
                StartCoroutine(WaitAndDo(7f, () => { StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()),40, Monster.monsterType.MON3)); }));


                break;
            case 1598: spawning = true; break;
            /////////////
            /// //////////////////////////////////////////////////////////
            case 1550:
                if (spawning == false) break;
                spawning = false;
                StartCoroutine(WaitAndDo(30f, () => { StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 10, Monster.monsterType.MON4)); }));

                StartCoroutine(WaitAndDo(3f, () => {
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
                    StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 5, Monster.monsterType.MON3));
                    StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 5, Monster.monsterType.MON3));
                    StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 5, Monster.monsterType.MON3));
                }));

                StartCoroutine(WaitAndDo(3f, () => { StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()),40, Monster.monsterType.MON1)); }));
                StartCoroutine(WaitAndDo(5f, () => { StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()),40, Monster.monsterType.MON2)); }));
                StartCoroutine(WaitAndDo(7f, () => { StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()),40, Monster.monsterType.MON3)); }));


                break;
            case 1548: spawning = true; break;
            /////////////
            /// //////////////////////////////////////////////////////////
            case 1500:
                if (spawning == false) break;
                spawning = false;
                StartCoroutine(WaitAndDo(30f, () => { StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 10, Monster.monsterType.MON4)); }));
                StartCoroutine(WaitAndDo(3f, () => {
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
                    StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 5, Monster.monsterType.MON3));
                    StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 5, Monster.monsterType.MON3));
                    StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 5, Monster.monsterType.MON3));
                }));

                StartCoroutine(WaitAndDo(3f, () => { StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()),40, Monster.monsterType.MON1)); }));
                StartCoroutine(WaitAndDo(5f, () => { StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()),40, Monster.monsterType.MON2)); }));
                StartCoroutine(WaitAndDo(7f, () => { StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()),40, Monster.monsterType.MON3)); }));


                break;
            case 1497: spawning = true; break;
            /////////////
            /// //////////////////////////////////////////////////////////
            case 1450:
                if (spawning == false) break;
                spawning = false;
                StartCoroutine(WaitAndDo(30f, () => { StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 10, Monster.monsterType.MON4)); }));
                StartCoroutine(WaitAndDo(3f, () => {
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
                    StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 5, Monster.monsterType.MON3));
                    StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 5, Monster.monsterType.MON3));
                    StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 5, Monster.monsterType.MON3));
                }));

                StartCoroutine(WaitAndDo(3f, () => { StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()),40, Monster.monsterType.MON1)); }));
                StartCoroutine(WaitAndDo(5f, () => { StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()),40, Monster.monsterType.MON2)); }));
                StartCoroutine(WaitAndDo(7f, () => { StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()),40, Monster.monsterType.MON3)); }));


                break;
            case 1448: spawning = true; break;
            /////////////
            /// //////////////////////////////////////////////////////////
            case 1400:
                if (spawning == false) break;
                spawning = false;
                StartCoroutine(WaitAndDo(30f, () => { StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 10, Monster.monsterType.MON4)); }));
                StartCoroutine(WaitAndDo(3f, () => {
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
                    StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 5, Monster.monsterType.MON3));
                    StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 5, Monster.monsterType.MON3));
                    StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 5, Monster.monsterType.MON3));
                }));

                StartCoroutine(WaitAndDo(3f, () => { StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()),40, Monster.monsterType.MON1)); }));
                StartCoroutine(WaitAndDo(5f, () => { StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()),40, Monster.monsterType.MON2)); }));
                StartCoroutine(WaitAndDo(7f, () => { StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()),40, Monster.monsterType.MON3)); }));


                break;
            case 1398: spawning = true; break;
            /////////////
            /// //////////////////////////////////////////////////////////
            case 1350:
                if (spawning == false) break;
                spawning = false;
                StartCoroutine(WaitAndDo(30f, () => { StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 10, Monster.monsterType.MON4)); }));
                StartCoroutine(WaitAndDo(3f, () => {
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
                    StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 5, Monster.monsterType.MON3));
                    StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 5, Monster.monsterType.MON3));
                    StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 5, Monster.monsterType.MON3));
                }));

                StartCoroutine(WaitAndDo(3f, () => { StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()),40, Monster.monsterType.MON1)); }));
                StartCoroutine(WaitAndDo(5f, () => { StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()),40, Monster.monsterType.MON2)); }));
                StartCoroutine(WaitAndDo(7f, () => { StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()),40, Monster.monsterType.MON3)); }));


                break;
            case 1348: spawning = true; break;
            /////////////
            /// //////////////////////////////////////////////////////////
            case 1300:
                if (spawning == false) break;
                spawning = false;
                StartCoroutine(WaitAndDo(30f, () => { StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 10, Monster.monsterType.MON6)); }));
                StartCoroutine(WaitAndDo(3f, () => {
                    StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 5, Monster.monsterType.MON3));
                    StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 5, Monster.monsterType.MON3));
                    StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 5, Monster.monsterType.MON3));
                }));
                StartCoroutine(WaitAndDo(10f, () => {
                    StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 5, Monster.monsterType.MON4));
                    StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 5, Monster.monsterType.MON4));
                    StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 5, Monster.monsterType.MON4));
                }));
                StartCoroutine(WaitAndDo(15f, () => {
                    StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 5, Monster.monsterType.MON5));
                    StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 5, Monster.monsterType.MON5));
                    StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 5, Monster.monsterType.MON5));
                }));

                StartCoroutine(WaitAndDo(3f, () => { StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()),40, Monster.monsterType.MON3)); }));
                StartCoroutine(WaitAndDo(5f, () => { StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()),40, Monster.monsterType.MON4)); }));
                StartCoroutine(WaitAndDo(7f, () => { StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()),40, Monster.monsterType.MON5)); }));


                break;
            case 1298: spawning = true; break;
            /////////////
            ////// //////////////////////////////////////////////////////////
            case 1250:
                if (spawning == false) break;
                spawning = false;
                StartCoroutine(WaitAndDo(30f, () => { StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 10, Monster.monsterType.MON6)); }));
                StartCoroutine(WaitAndDo(3f, () => {
                    StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 5, Monster.monsterType.MON3));
                    StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 5, Monster.monsterType.MON3));
                    StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 5, Monster.monsterType.MON3));
                }));
                StartCoroutine(WaitAndDo(10f, () => {
                    StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 5, Monster.monsterType.MON4));
                    StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 5, Monster.monsterType.MON4));
                    StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 5, Monster.monsterType.MON4));
                }));
                StartCoroutine(WaitAndDo(15f, () => {
                    StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 5, Monster.monsterType.MON5));
                    StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 5, Monster.monsterType.MON5));
                    StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 5, Monster.monsterType.MON5));
                }));

                StartCoroutine(WaitAndDo(3f, () => { StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()),40, Monster.monsterType.MON3)); }));
                StartCoroutine(WaitAndDo(5f, () => { StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()),40, Monster.monsterType.MON4)); }));
                StartCoroutine(WaitAndDo(7f, () => { StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()),40, Monster.monsterType.MON5)); }));


                break;
            case 1248: spawning = true; break;
            /////////////
            ////// //////////////////////////////////////////////////////////
            case 1200:
                if (spawning == false) break;
                spawning = false;
                StartCoroutine(WaitAndDo(30f, () => { StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 10, Monster.monsterType.MON6)); }));
                StartCoroutine(WaitAndDo(3f, () => {
                    StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 5, Monster.monsterType.MON3));
                    StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 5, Monster.monsterType.MON3));
                    StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 5, Monster.monsterType.MON3));
                }));
                StartCoroutine(WaitAndDo(10f, () => {
                    StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 5, Monster.monsterType.MON4));
                    StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 5, Monster.monsterType.MON4));
                    StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 5, Monster.monsterType.MON4));
                }));
                StartCoroutine(WaitAndDo(15f, () => {
                    StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 5, Monster.monsterType.MON5));
                    StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 5, Monster.monsterType.MON5));
                    StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 5, Monster.monsterType.MON5));
                }));

                StartCoroutine(WaitAndDo(3f, () => { StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()),40, Monster.monsterType.MON3)); }));
                StartCoroutine(WaitAndDo(5f, () => { StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()),40, Monster.monsterType.MON4)); }));
                StartCoroutine(WaitAndDo(7f, () => { StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()),40, Monster.monsterType.MON5)); }));


                break;
            case 1198: spawning = true; break;
            /////////////
            ////// //////////////////////////////////////////////////////////
            case 1150:
                if (spawning == false) break;
                spawning = false;
                StartCoroutine(WaitAndDo(30f, () => { StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 10, Monster.monsterType.MON6)); }));
                StartCoroutine(WaitAndDo(3f, () => {
                    StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 5, Monster.monsterType.MON3));
                    StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 5, Monster.monsterType.MON3));
                    StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 5, Monster.monsterType.MON3));
                }));
                StartCoroutine(WaitAndDo(10f, () => {
                    StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 5, Monster.monsterType.MON4));
                    StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 5, Monster.monsterType.MON4));
                    StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 5, Monster.monsterType.MON4));
                }));
                StartCoroutine(WaitAndDo(15f, () => {
                    StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 5, Monster.monsterType.MON5));
                    StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 5, Monster.monsterType.MON5));
                    StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 5, Monster.monsterType.MON5));
                }));

                StartCoroutine(WaitAndDo(3f, () => { StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()),40, Monster.monsterType.MON3)); }));
                StartCoroutine(WaitAndDo(5f, () => { StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()),40, Monster.monsterType.MON4)); }));
                StartCoroutine(WaitAndDo(7f, () => { StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()),40, Monster.monsterType.MON5)); }));


                break;
            case 1148: spawning = true; break;
            /////////////
            ////// //////////////////////////////////////////////////////////
            case 1100:
                if (spawning == false) break;
                spawning = false;
                StartCoroutine(WaitAndDo(30f, () => { StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 10, Monster.monsterType.MON6)); }));
                StartCoroutine(WaitAndDo(3f, () => {
                    StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 5, Monster.monsterType.MON3));
                    StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 5, Monster.monsterType.MON3));
                    StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 5, Monster.monsterType.MON3));
                }));
                StartCoroutine(WaitAndDo(10f, () => {
                    StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 5, Monster.monsterType.MON4));
                    StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 5, Monster.monsterType.MON4));
                    StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 5, Monster.monsterType.MON4));
                }));
                StartCoroutine(WaitAndDo(15f, () => {
                    StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 5, Monster.monsterType.MON5));
                    StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 5, Monster.monsterType.MON5));
                    StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 5, Monster.monsterType.MON5));
                }));

                StartCoroutine(WaitAndDo(3f, () => { StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()),40, Monster.monsterType.MON3)); }));
                StartCoroutine(WaitAndDo(5f, () => { StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()),40, Monster.monsterType.MON4)); }));
                StartCoroutine(WaitAndDo(7f, () => { StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()),40, Monster.monsterType.MON5)); }));


                break;
            case 1098: spawning = true; break;
            /////////////
            ////// //////////////////////////////////////////////////////////
            case 1050:
                if (spawning == false) break;
                spawning = false;
                StartCoroutine(WaitAndDo(30f, () => { StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 10, Monster.monsterType.MON6)); }));
                StartCoroutine(WaitAndDo(3f, () => {
                    StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 5, Monster.monsterType.MON3));
                    StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 5, Monster.monsterType.MON3));
                    StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 5, Monster.monsterType.MON3));
                }));
                StartCoroutine(WaitAndDo(10f, () => {
                    StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 5, Monster.monsterType.MON4));
                    StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 5, Monster.monsterType.MON4));
                    StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 5, Monster.monsterType.MON4));
                }));
                StartCoroutine(WaitAndDo(15f, () => {
                    StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 5, Monster.monsterType.MON5));
                    StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 5, Monster.monsterType.MON5));
                    StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 5, Monster.monsterType.MON5));
                }));

                StartCoroutine(WaitAndDo(3f, () => { StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()),40, Monster.monsterType.MON3)); }));
                StartCoroutine(WaitAndDo(5f, () => { StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()),40, Monster.monsterType.MON4)); }));
                StartCoroutine(WaitAndDo(7f, () => { StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()),40, Monster.monsterType.MON5)); }));


                break;
            case 1048: spawning = true; break;
            /////////////
            ////// //////////////////////////////////////////////////////////
            case 1000:
                if (spawning == false) break;
                spawning = false;
                StartCoroutine(WaitAndDo(30f, () => { StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 10, Monster.monsterType.MON6)); }));
                StartCoroutine(WaitAndDo(3f, () => {
                    StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 5, Monster.monsterType.MON3));
                    StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 5, Monster.monsterType.MON3));
                    StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 5, Monster.monsterType.MON3));
                }));
                StartCoroutine(WaitAndDo(10f, () => {
                    StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 5, Monster.monsterType.MON4));
                    StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 5, Monster.monsterType.MON4));
                    StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 5, Monster.monsterType.MON4));
                }));
                StartCoroutine(WaitAndDo(15f, () => {
                    StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 5, Monster.monsterType.MON5));
                    StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 5, Monster.monsterType.MON5));
                    StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 5, Monster.monsterType.MON5));
                }));

                StartCoroutine(WaitAndDo(3f, () => { StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()),40, Monster.monsterType.MON3)); }));
                StartCoroutine(WaitAndDo(5f, () => { StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()),40, Monster.monsterType.MON4)); }));
                StartCoroutine(WaitAndDo(7f, () => { StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()),40, Monster.monsterType.MON5)); }));


                break;
            case 998: spawning = true; break;
            /////////////
            ////// //////////////////////////////////////////////////////////
            case 950:
                if (spawning == false) break;
                spawning = false;
                StartCoroutine(WaitAndDo(30f, () => { StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 10, Monster.monsterType.MON6)); }));
                StartCoroutine(WaitAndDo(3f, () => {
                    StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 5, Monster.monsterType.MON3));
                    StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 5, Monster.monsterType.MON3));
                    StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 5, Monster.monsterType.MON3));
                }));
                StartCoroutine(WaitAndDo(10f, () => {
                    StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 5, Monster.monsterType.MON4));
                    StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 5, Monster.monsterType.MON4));
                    StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 5, Monster.monsterType.MON4));
                }));
                StartCoroutine(WaitAndDo(15f, () => {
                    StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 5, Monster.monsterType.MON5));
                    StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 5, Monster.monsterType.MON5));
                    StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 5, Monster.monsterType.MON5));
                }));

                StartCoroutine(WaitAndDo(3f, () => { StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()),40, Monster.monsterType.MON3)); }));
                StartCoroutine(WaitAndDo(5f, () => { StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()),40, Monster.monsterType.MON4)); }));
                StartCoroutine(WaitAndDo(7f, () => { StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()),40, Monster.monsterType.MON5)); }));


                break;
            case 948: spawning = true; break;
            /////////////
            ////// //////////////////////////////////////////////////////////
            case 900:
                if (spawning == false) break;
                spawning = false;
                StartCoroutine(WaitAndDo(30f, () => { StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 10, Monster.monsterType.MON6)); }));
                StartCoroutine(WaitAndDo(3f, () => {
                    StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 5, Monster.monsterType.MON3));
                    StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 5, Monster.monsterType.MON3));
                    StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 5, Monster.monsterType.MON3));
                }));
                StartCoroutine(WaitAndDo(10f, () => {
                    StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 5, Monster.monsterType.MON4));
                    StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 5, Monster.monsterType.MON4));
                    StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 5, Monster.monsterType.MON4));
                }));
                StartCoroutine(WaitAndDo(15f, () => {
                    StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 5, Monster.monsterType.MON5));
                    StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 5, Monster.monsterType.MON5));
                    StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 5, Monster.monsterType.MON5));
                }));

                StartCoroutine(WaitAndDo(3f, () => { StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()),40, Monster.monsterType.MON3)); }));
                StartCoroutine(WaitAndDo(5f, () => { StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()),40, Monster.monsterType.MON4)); }));
                StartCoroutine(WaitAndDo(7f, () => { StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()),40, Monster.monsterType.MON5)); }));


                break;
            case 898: spawning = true; break;
            /////////////
            ////// //////////////////////////////////////////////////////////
            case 850:
                if (spawning == false) break;
                spawning = false;
                StartCoroutine(WaitAndDo(30f, () => { StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 10, Monster.monsterType.MON6)); }));
                StartCoroutine(WaitAndDo(3f, () => {
                    StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 5, Monster.monsterType.MON3));
                    StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 5, Monster.monsterType.MON3));
                    StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 5, Monster.monsterType.MON3));
                }));
                StartCoroutine(WaitAndDo(10f, () => {
                    StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 5, Monster.monsterType.MON4));
                    StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 5, Monster.monsterType.MON4));
                    StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 5, Monster.monsterType.MON4));
                }));
                StartCoroutine(WaitAndDo(15f, () => {
                    StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 5, Monster.monsterType.MON5));
                    StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 5, Monster.monsterType.MON5));
                    StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 5, Monster.monsterType.MON5));
                }));

                StartCoroutine(WaitAndDo(3f, () => { StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()),40, Monster.monsterType.MON3)); }));
                StartCoroutine(WaitAndDo(5f, () => { StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()),40, Monster.monsterType.MON4)); }));
                StartCoroutine(WaitAndDo(7f, () => { StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()),40, Monster.monsterType.MON5)); }));


                break;
            case 848: spawning = true; break;
            /////////////
            ////// //////////////////////////////////////////////////////////
            case 800:
                if (spawning == false) break;
                spawning = false;
                StartCoroutine(WaitAndDo(30f, () => { StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 5, Monster.monsterType.MON8)); }));
                StartCoroutine(WaitAndDo(3f, () => {
                    StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 5, Monster.monsterType.MON5));
                    StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 5, Monster.monsterType.MON5));
                    StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 5, Monster.monsterType.MON5));
                }));
                StartCoroutine(WaitAndDo(10f, () => {
                    StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 5, Monster.monsterType.MON6));
                    StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 5, Monster.monsterType.MON6));
                    StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 5, Monster.monsterType.MON6));
                }));
                StartCoroutine(WaitAndDo(15f, () => {
                    StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 5, Monster.monsterType.MON7));
                    StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 5, Monster.monsterType.MON7));
                    StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 5, Monster.monsterType.MON7));
                }));

                StartCoroutine(WaitAndDo(3f, () => { StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 30, Monster.monsterType.MON5)); }));
                StartCoroutine(WaitAndDo(5f, () => { StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 30, Monster.monsterType.MON6)); }));
                StartCoroutine(WaitAndDo(7f, () => { StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 30, Monster.monsterType.MON7)); }));


                break;
            case 798: spawning = true; break;
            /////////////
            ///
            ////// //////////////////////////////////////////////////////////
            case 750:
                if (spawning == false) break;
                spawning = false;
                StartCoroutine(WaitAndDo(30f, () => { StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 5, Monster.monsterType.MON8)); }));
                StartCoroutine(WaitAndDo(3f, () => {
                    StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 5, Monster.monsterType.MON5));
                    StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 5, Monster.monsterType.MON5));
                    StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 5, Monster.monsterType.MON5));
                }));
                StartCoroutine(WaitAndDo(10f, () => {
                    StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 5, Monster.monsterType.MON6));
                    StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 5, Monster.monsterType.MON6));
                    StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 5, Monster.monsterType.MON6));
                }));
                StartCoroutine(WaitAndDo(15f, () => {
                    StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 5, Monster.monsterType.MON7));
                    StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 5, Monster.monsterType.MON7));
                    StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 5, Monster.monsterType.MON7));
                }));

                StartCoroutine(WaitAndDo(3f, () => { StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 30, Monster.monsterType.MON5)); }));
                StartCoroutine(WaitAndDo(5f, () => { StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 30, Monster.monsterType.MON6)); }));
                StartCoroutine(WaitAndDo(7f, () => { StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 30, Monster.monsterType.MON7)); }));


                break;
            case 748: spawning = true; break;
            /////////////
            ///   ////// //////////////////////////////////////////////////////////
            case 700:
                if (spawning == false) break;
                spawning = false;
                StartCoroutine(WaitAndDo(30f, () => { StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 5, Monster.monsterType.MON8)); }));
                StartCoroutine(WaitAndDo(3f, () => {
                    StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 5, Monster.monsterType.MON5));
                    StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 5, Monster.monsterType.MON5));
                    StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 5, Monster.monsterType.MON5));
                }));
                StartCoroutine(WaitAndDo(10f, () => {
                    StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 5, Monster.monsterType.MON6));
                    StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 5, Monster.monsterType.MON6));
                    StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 5, Monster.monsterType.MON6));
                }));
                StartCoroutine(WaitAndDo(15f, () => {
                    StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 5, Monster.monsterType.MON7));
                    StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 5, Monster.monsterType.MON7));
                    StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 5, Monster.monsterType.MON7));
                }));

                StartCoroutine(WaitAndDo(3f, () => { StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 30, Monster.monsterType.MON5)); }));
                StartCoroutine(WaitAndDo(5f, () => { StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 30, Monster.monsterType.MON6)); }));
                StartCoroutine(WaitAndDo(7f, () => { StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 30, Monster.monsterType.MON7)); }));


                break;
            case 698: spawning = true; break;
            /////////////
            ///   ////// //////////////////////////////////////////////////////////
            case 650:
                if (spawning == false) break;
                spawning = false;
                StartCoroutine(WaitAndDo(30f, () => { StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 5, Monster.monsterType.MON8)); }));
                StartCoroutine(WaitAndDo(3f, () => {
                    StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 5, Monster.monsterType.MON5));
                    StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 5, Monster.monsterType.MON5));
                    StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 5, Monster.monsterType.MON5));
                }));
                StartCoroutine(WaitAndDo(10f, () => {
                    StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 5, Monster.monsterType.MON6));
                    StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 5, Monster.monsterType.MON6));
                    StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 5, Monster.monsterType.MON6));
                }));
                StartCoroutine(WaitAndDo(15f, () => {
                    StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 5, Monster.monsterType.MON7));
                    StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 5, Monster.monsterType.MON7));
                    StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 5, Monster.monsterType.MON7));
                }));

                StartCoroutine(WaitAndDo(3f, () => { StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 30, Monster.monsterType.MON5)); }));
                StartCoroutine(WaitAndDo(5f, () => { StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 30, Monster.monsterType.MON6)); }));
                StartCoroutine(WaitAndDo(7f, () => { StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 30, Monster.monsterType.MON7)); }));


                break;
            case 648: spawning = true; break;
            /////////////
            ///   ////// //////////////////////////////////////////////////////////
            case 600:
                if (spawning == false) break;
                spawning = false;
                StartCoroutine(WaitAndDo(30f, () => { StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 5, Monster.monsterType.MON8)); }));
                StartCoroutine(WaitAndDo(3f, () => {
                    StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 5, Monster.monsterType.MON5));
                    StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 5, Monster.monsterType.MON5));
                    StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 5, Monster.monsterType.MON5));
                }));
                StartCoroutine(WaitAndDo(10f, () => {
                    StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 5, Monster.monsterType.MON6));
                    StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 5, Monster.monsterType.MON6));
                    StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 5, Monster.monsterType.MON6));
                }));
                StartCoroutine(WaitAndDo(15f, () => {
                    StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 5, Monster.monsterType.MON7));
                    StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 5, Monster.monsterType.MON7));
                    StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 5, Monster.monsterType.MON7));
                }));

                StartCoroutine(WaitAndDo(3f, () => { StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 30, Monster.monsterType.MON5)); }));
                StartCoroutine(WaitAndDo(5f, () => { StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 30, Monster.monsterType.MON6)); }));
                StartCoroutine(WaitAndDo(7f, () => { StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 30, Monster.monsterType.MON7)); }));


                break;
            case 598: spawning = true; break;
            /////////////
            ///   ////// //////////////////////////////////////////////////////////
            case 550:
                if (spawning == false) break;
                spawning = false;
                StartCoroutine(WaitAndDo(30f, () => { StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 5, Monster.monsterType.MON8)); }));
                StartCoroutine(WaitAndDo(3f, () => {
                    StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 5, Monster.monsterType.MON5));
                    StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 5, Monster.monsterType.MON5));
                    StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 5, Monster.monsterType.MON5));
                }));
                StartCoroutine(WaitAndDo(10f, () => {
                    StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 5, Monster.monsterType.MON6));
                    StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 5, Monster.monsterType.MON6));
                    StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 5, Monster.monsterType.MON6));
                }));
                StartCoroutine(WaitAndDo(15f, () => {
                    StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 5, Monster.monsterType.MON7));
                    StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 5, Monster.monsterType.MON7));
                    StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 5, Monster.monsterType.MON7));
                }));

                StartCoroutine(WaitAndDo(3f, () => { StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 30, Monster.monsterType.MON5)); }));
                StartCoroutine(WaitAndDo(5f, () => { StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 30, Monster.monsterType.MON6)); }));
                StartCoroutine(WaitAndDo(7f, () => { StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 30, Monster.monsterType.MON7)); }));


                break;
            case 548: spawning = true; break;
            /////////////
            ///   ////// //////////////////////////////////////////////////////////
            case 500:
                if (spawning == false) break;
                spawning = false;
                StartCoroutine(WaitAndDo(30f, () => { StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 5, Monster.monsterType.MON8)); }));
                StartCoroutine(WaitAndDo(3f, () => {
                    StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 5, Monster.monsterType.MON5));
                    StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 5, Monster.monsterType.MON5));
                    StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 5, Monster.monsterType.MON5));
                }));
                StartCoroutine(WaitAndDo(10f, () => {
                    StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 5, Monster.monsterType.MON6));
                    StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 5, Monster.monsterType.MON6));
                    StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 5, Monster.monsterType.MON6));
                }));
                StartCoroutine(WaitAndDo(15f, () => {
                    StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 5, Monster.monsterType.MON7));
                    StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 5, Monster.monsterType.MON7));
                    StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 5, Monster.monsterType.MON7));
                }));

                StartCoroutine(WaitAndDo(3f, () => { StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 30, Monster.monsterType.MON5)); }));
                StartCoroutine(WaitAndDo(5f, () => { StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 30, Monster.monsterType.MON6)); }));
                StartCoroutine(WaitAndDo(7f, () => { StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 30, Monster.monsterType.MON7)); }));


                break;
            case 498: spawning = true; break;
            /////////////
            ///   ////// //////////////////////////////////////////////////////////
            case 450:
                if (spawning == false) break;
                spawning = false;
                StartCoroutine(WaitAndDo(30f, () => { StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 5, Monster.monsterType.MON8)); }));
                StartCoroutine(WaitAndDo(3f, () => {
                    StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 5, Monster.monsterType.MON5));
                    StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 5, Monster.monsterType.MON5));
                    StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 5, Monster.monsterType.MON5));
                }));
                StartCoroutine(WaitAndDo(10f, () => {
                    StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 5, Monster.monsterType.MON6));
                    StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 5, Monster.monsterType.MON6));
                    StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 5, Monster.monsterType.MON6));
                }));
                StartCoroutine(WaitAndDo(15f, () => {
                    StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 5, Monster.monsterType.MON7));
                    StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 5, Monster.monsterType.MON7));
                    StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 5, Monster.monsterType.MON7));
                }));

                StartCoroutine(WaitAndDo(3f, () => { StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 30, Monster.monsterType.MON5)); }));
                StartCoroutine(WaitAndDo(5f, () => { StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 30, Monster.monsterType.MON6)); }));
                StartCoroutine(WaitAndDo(7f, () => { StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 30, Monster.monsterType.MON7)); }));


                break;
            case 448: spawning = true; break;
            /////////////
            ///   ////// //////////////////////////////////////////////////////////
            case 400:
                if (spawning == false) break;
                spawning = false;
                StartCoroutine(WaitAndDo(30f, () => { StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 5, Monster.monsterType.MON8)); }));
                StartCoroutine(WaitAndDo(3f, () => {
                    StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 5, Monster.monsterType.MON5));
                    StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 5, Monster.monsterType.MON5));
                    StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 5, Monster.monsterType.MON5));
                }));
                StartCoroutine(WaitAndDo(10f, () => {
                    StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 5, Monster.monsterType.MON6));
                    StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 5, Monster.monsterType.MON6));
                    StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 5, Monster.monsterType.MON6));
                }));
                StartCoroutine(WaitAndDo(15f, () => {
                    StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 5, Monster.monsterType.MON7));
                    StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 5, Monster.monsterType.MON7));
                    StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 5, Monster.monsterType.MON7));
                }));

                StartCoroutine(WaitAndDo(3f, () => { StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 30, Monster.monsterType.MON5)); }));
                StartCoroutine(WaitAndDo(5f, () => { StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 30, Monster.monsterType.MON6)); }));
                StartCoroutine(WaitAndDo(7f, () => { StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 30, Monster.monsterType.MON7)); }));


                break;
            case 398: spawning = true; break;
            /////////////
            ///   ////// //////////////////////////////////////////////////////////
            case 350:
                if (spawning == false) break;
                spawning = false;
                StartCoroutine(WaitAndDo(30f, () => { StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 5, Monster.monsterType.MON8)); }));
                StartCoroutine(WaitAndDo(3f, () => {
                    StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 5, Monster.monsterType.MON5));
                    StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 5, Monster.monsterType.MON5));
                    StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 5, Monster.monsterType.MON5));
                }));
                StartCoroutine(WaitAndDo(10f, () => {
                    StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 5, Monster.monsterType.MON6));
                    StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 5, Monster.monsterType.MON6));
                    StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 5, Monster.monsterType.MON6));
                }));
                StartCoroutine(WaitAndDo(15f, () => {
                    StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 5, Monster.monsterType.MON7));
                    StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 5, Monster.monsterType.MON7));
                    StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 5, Monster.monsterType.MON7));
                }));

                StartCoroutine(WaitAndDo(3f, () => { StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 30, Monster.monsterType.MON5)); }));
                StartCoroutine(WaitAndDo(5f, () => { StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 30, Monster.monsterType.MON6)); }));
                StartCoroutine(WaitAndDo(7f, () => { StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 30, Monster.monsterType.MON7)); }));


                break;
            case 348: spawning = true; break;
            /////////////
            ///   ////// //////////////////////////////////////////////////////////
            case 300:
                if (spawning == false) break;
                spawning = false;
                StartCoroutine(WaitAndDo(30f, () => { StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()),10 , Monster.monsterType.MON1)); }));
                StartCoroutine(WaitAndDo(30f, () => { StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 10, Monster.monsterType.MON2)); }));
                StartCoroutine(WaitAndDo(30f, () => { StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 10, Monster.monsterType.MON3)); }));
                StartCoroutine(WaitAndDo(30f, () => { StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 10, Monster.monsterType.MON4)); }));
                StartCoroutine(WaitAndDo(30f, () => { StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 10, Monster.monsterType.MON5)); }));
                StartCoroutine(WaitAndDo(3f, () => {
                    StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 5, Monster.monsterType.MON6));
                    StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 5, Monster.monsterType.MON6));
                    StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 5, Monster.monsterType.MON6));
                }));
                StartCoroutine(WaitAndDo(10f, () => {
                    StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 5, Monster.monsterType.MON7));
                    StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 5, Monster.monsterType.MON7));
                    StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 5, Monster.monsterType.MON7));
                }));
                StartCoroutine(WaitAndDo(15f, () => {
                    StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 5, Monster.monsterType.MON8));
                    StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 5, Monster.monsterType.MON8));
                    StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 5, Monster.monsterType.MON8));
                }));

                StartCoroutine(WaitAndDo(3f, () => { StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 30, Monster.monsterType.MON6)); }));
                StartCoroutine(WaitAndDo(5f, () => { StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 30, Monster.monsterType.MON7)); }));
                StartCoroutine(WaitAndDo(7f, () => { StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 30, Monster.monsterType.MON8)); }));


                break;
            case 298: spawning = true; break;
            /////////////
            /// ///   ////// //////////////////////////////////////////////////////////
            case 250:
                if (spawning == false) break;
                spawning = false;
                StartCoroutine(WaitAndDo(30f, () => { StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 10, Monster.monsterType.MON1)); }));
                StartCoroutine(WaitAndDo(30f, () => { StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 10, Monster.monsterType.MON2)); }));
                StartCoroutine(WaitAndDo(30f, () => { StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 10, Monster.monsterType.MON3)); }));
                StartCoroutine(WaitAndDo(30f, () => { StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 10, Monster.monsterType.MON4)); }));
                StartCoroutine(WaitAndDo(30f, () => { StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 10, Monster.monsterType.MON5)); }));
                StartCoroutine(WaitAndDo(3f, () => {
                    StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 5, Monster.monsterType.MON6));
                    StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 5, Monster.monsterType.MON6));
                    StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 5, Monster.monsterType.MON6));
                }));
                StartCoroutine(WaitAndDo(10f, () => {
                    StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 5, Monster.monsterType.MON7));
                    StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 5, Monster.monsterType.MON7));
                    StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 5, Monster.monsterType.MON7));
                }));
                StartCoroutine(WaitAndDo(15f, () => {
                    StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 5, Monster.monsterType.MON8));
                    StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 5, Monster.monsterType.MON8));
                    StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 5, Monster.monsterType.MON8));
                }));

                StartCoroutine(WaitAndDo(3f, () => { StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 30, Monster.monsterType.MON6)); }));
                StartCoroutine(WaitAndDo(5f, () => { StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 30, Monster.monsterType.MON7)); }));
                StartCoroutine(WaitAndDo(7f, () => { StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 30, Monster.monsterType.MON8)); }));


                break;
            case 248: spawning = true; break;
            /////////////
            /// ///   ////// //////////////////////////////////////////////////////////
            case 200:
                if (spawning == false) break;
                spawning = false;
                StartCoroutine(WaitAndDo(30f, () => { StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 10, Monster.monsterType.MON1)); }));
                StartCoroutine(WaitAndDo(30f, () => { StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 10, Monster.monsterType.MON2)); }));
                StartCoroutine(WaitAndDo(30f, () => { StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 10, Monster.monsterType.MON3)); }));
                StartCoroutine(WaitAndDo(30f, () => { StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 10, Monster.monsterType.MON4)); }));
                StartCoroutine(WaitAndDo(30f, () => { StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 10, Monster.monsterType.MON5)); }));
                StartCoroutine(WaitAndDo(3f, () => {
                    StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 5, Monster.monsterType.MON6));
                    StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 5, Monster.monsterType.MON6));
                    StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 5, Monster.monsterType.MON6));
                }));
                StartCoroutine(WaitAndDo(10f, () => {
                    StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 5, Monster.monsterType.MON7));
                    StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 5, Monster.monsterType.MON7));
                    StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 5, Monster.monsterType.MON7));
                }));
                StartCoroutine(WaitAndDo(15f, () => {
                    StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 5, Monster.monsterType.MON8));
                    StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 5, Monster.monsterType.MON8));
                    StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 5, Monster.monsterType.MON8));
                }));

                StartCoroutine(WaitAndDo(3f, () => { StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 60, Monster.monsterType.MON6)); }));
                StartCoroutine(WaitAndDo(5f, () => { StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 60, Monster.monsterType.MON7)); }));
                StartCoroutine(WaitAndDo(7f, () => { StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 60, Monster.monsterType.MON8)); }));


                break;
            case 198: spawning = true; break;
            /////////////
            /// ///   ////// //////////////////////////////////////////////////////////
            case 150:
                if (spawning == false) break;
                spawning = false;
                StartCoroutine(WaitAndDo(30f, () => { StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 10, Monster.monsterType.MON1)); }));
                StartCoroutine(WaitAndDo(30f, () => { StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 10, Monster.monsterType.MON2)); }));
                StartCoroutine(WaitAndDo(30f, () => { StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 10, Monster.monsterType.MON3)); }));
                StartCoroutine(WaitAndDo(30f, () => { StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 10, Monster.monsterType.MON4)); }));
                StartCoroutine(WaitAndDo(30f, () => { StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 10, Monster.monsterType.MON5)); }));
                StartCoroutine(WaitAndDo(3f, () => {
                    StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 5, Monster.monsterType.MON6));
                    StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 5, Monster.monsterType.MON6));
                    StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 5, Monster.monsterType.MON6));
                }));
                StartCoroutine(WaitAndDo(10f, () => {
                    StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 5, Monster.monsterType.MON7));
                    StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 5, Monster.monsterType.MON7));
                    StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 5, Monster.monsterType.MON7));
                }));
                StartCoroutine(WaitAndDo(15f, () => {
                    StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 5, Monster.monsterType.MON8));
                    StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 5, Monster.monsterType.MON8));
                    StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 5, Monster.monsterType.MON8));
                }));

                StartCoroutine(WaitAndDo(3f, () => { StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 70, Monster.monsterType.MON6)); }));
                StartCoroutine(WaitAndDo(5f, () => { StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 70, Monster.monsterType.MON7)); }));
                StartCoroutine(WaitAndDo(7f, () => { StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 70, Monster.monsterType.MON8)); }));


                break;
            case 148: spawning = true; break;
            /////////////
            /// ///   ////// //////////////////////////////////////////////////////////
            case 100:
                if (spawning == false) break;
                spawning = false;
                StartCoroutine(WaitAndDo(3f, () => { StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 10, Monster.monsterType.MON1)); }));
                StartCoroutine(WaitAndDo(4f, () => { StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 10, Monster.monsterType.MON2)); }));
                StartCoroutine(WaitAndDo(5f, () => { StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 10, Monster.monsterType.MON3)); }));
                StartCoroutine(WaitAndDo(6f, () => { StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 10, Monster.monsterType.MON4)); }));
                StartCoroutine(WaitAndDo(7f, () => { StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 10, Monster.monsterType.MON5)); }));
                StartCoroutine(WaitAndDo(3f, () => {
                    StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 5, Monster.monsterType.MON6));
                    StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 5, Monster.monsterType.MON6));
                    StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 5, Monster.monsterType.MON6));
                }));
                StartCoroutine(WaitAndDo(10f, () => {
                    StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 5, Monster.monsterType.MON7));
                    StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 5, Monster.monsterType.MON7));
                    StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 5, Monster.monsterType.MON7));
                }));
                StartCoroutine(WaitAndDo(15f, () => {
                    StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 5, Monster.monsterType.MON8));
                    StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 5, Monster.monsterType.MON8));
                    StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 5, Monster.monsterType.MON8));
                }));

                StartCoroutine(WaitAndDo(3f, () => { StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 80, Monster.monsterType.MON6)); }));
                StartCoroutine(WaitAndDo(5f, () => { StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 80, Monster.monsterType.MON7)); }));
                StartCoroutine(WaitAndDo(7f, () => { StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 100, Monster.monsterType.MON8)); }));


                break;
            case 98: spawning = true; break;
            /////////////
            ///   /// ///   ////// //////////////////////////////////////////////////////////
            case 80:
                if (spawning == false) break;
                spawning = false;
                StartCoroutine(WaitAndDo(3f, () => { StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 10, Monster.monsterType.MON1)); }));
                StartCoroutine(WaitAndDo(4f, () => { StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 10, Monster.monsterType.MON2)); }));
                StartCoroutine(WaitAndDo(5f, () => { StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 10, Monster.monsterType.MON3)); }));
                StartCoroutine(WaitAndDo(6f, () => { StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 10, Monster.monsterType.MON4)); }));
                StartCoroutine(WaitAndDo(7f, () => { StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 10, Monster.monsterType.MON5)); }));
                StartCoroutine(WaitAndDo(3f, () => {
                    StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 5, Monster.monsterType.MON6));
                    StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 5, Monster.monsterType.MON6));
                    StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 5, Monster.monsterType.MON6));
                }));
                StartCoroutine(WaitAndDo(10f, () => {
                    StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 5, Monster.monsterType.MON7));
                    StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 5, Monster.monsterType.MON7));
                    StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 5, Monster.monsterType.MON7));
                }));
                StartCoroutine(WaitAndDo(15f, () => {
                    StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 5, Monster.monsterType.MON8));
                    StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 5, Monster.monsterType.MON8));
                    StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 5, Monster.monsterType.MON8));
                }));

                StartCoroutine(WaitAndDo(3f, () => { StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 80, Monster.monsterType.MON6)); }));
                StartCoroutine(WaitAndDo(5f, () => { StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 80, Monster.monsterType.MON7)); }));
                StartCoroutine(WaitAndDo(7f, () => { StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 100, Monster.monsterType.MON8)); }));


                break;
            case 78: spawning = true; break;
                /////////////



   /// ///   ////// //////////////////////////////////////////////////////////
            case 60:
                if (spawning == false) break;
                spawning = false;
                StartCoroutine(WaitAndDo(3f, () => { StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 10, Monster.monsterType.MON1)); }));
                StartCoroutine(WaitAndDo(4f, () => { StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 10, Monster.monsterType.MON2)); }));
                StartCoroutine(WaitAndDo(5f, () => { StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 10, Monster.monsterType.MON3)); }));
                StartCoroutine(WaitAndDo(6f, () => { StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 10, Monster.monsterType.MON4)); }));
                StartCoroutine(WaitAndDo(7f, () => { StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 10, Monster.monsterType.MON5)); }));
                StartCoroutine(WaitAndDo(3f, () => {
                    StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 5, Monster.monsterType.MON6));
                    StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 5, Monster.monsterType.MON6));
                    StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 5, Monster.monsterType.MON6));
                }));
                StartCoroutine(WaitAndDo(10f, () => {
                    StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 5, Monster.monsterType.MON7));
                    StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 5, Monster.monsterType.MON7));
                    StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 5, Monster.monsterType.MON7));
                }));
                StartCoroutine(WaitAndDo(15f, () => {
                    StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 5, Monster.monsterType.MON8));
                    StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 5, Monster.monsterType.MON8));
                    StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 5, Monster.monsterType.MON8));
                }));

                StartCoroutine(WaitAndDo(3f, () => { StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 40, Monster.monsterType.MON6)); }));
                StartCoroutine(WaitAndDo(5f, () => { StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 40, Monster.monsterType.MON7)); }));
                StartCoroutine(WaitAndDo(7f, () => { StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 50, Monster.monsterType.MON8)); }));


                break;
            case 58: spawning = true; break;
            /////////////
            ///
            /// ///   ////// //////////////////////////////////////////////////////////
            case 40:
                if (spawning == false) break;
                spawning = false;
                StartCoroutine(WaitAndDo(3f, () => { StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 10, Monster.monsterType.MON1)); }));
                StartCoroutine(WaitAndDo(4f, () => { StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 10, Monster.monsterType.MON2)); }));
                StartCoroutine(WaitAndDo(5f, () => { StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 10, Monster.monsterType.MON3)); }));
                StartCoroutine(WaitAndDo(6f, () => { StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 10, Monster.monsterType.MON4)); }));
                StartCoroutine(WaitAndDo(7f, () => { StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 10, Monster.monsterType.MON5)); }));
                StartCoroutine(WaitAndDo(3f, () => {
                    StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 5, Monster.monsterType.MON6));
                    StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 5, Monster.monsterType.MON6));
                    StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 5, Monster.monsterType.MON6));
                }));
                StartCoroutine(WaitAndDo(10f, () => {
                    StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 5, Monster.monsterType.MON7));
                    StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 5, Monster.monsterType.MON7));
                    StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 5, Monster.monsterType.MON7));
                }));
                StartCoroutine(WaitAndDo(15f, () => {
                    StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 5, Monster.monsterType.MON8));
                    StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 5, Monster.monsterType.MON8));
                    StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 5, Monster.monsterType.MON8));
                }));

                StartCoroutine(WaitAndDo(3f, () => { StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 40, Monster.monsterType.MON6)); }));
                StartCoroutine(WaitAndDo(5f, () => { StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 40, Monster.monsterType.MON7)); }));
                StartCoroutine(WaitAndDo(7f, () => { StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 50, Monster.monsterType.MON8)); }));


                break;
            case 38: spawning = true; break;
            /////////////
            ///
            /// ///   ////// //////////////////////////////////////////////////////////
            case 20:
                if (spawning == false) break;
                spawning = false;
                StartCoroutine(WaitAndDo(3f, () => { StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 10, Monster.monsterType.MON1)); }));
                StartCoroutine(WaitAndDo(4f, () => { StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 10, Monster.monsterType.MON2)); }));
                StartCoroutine(WaitAndDo(5f, () => { StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 10, Monster.monsterType.MON3)); }));
                StartCoroutine(WaitAndDo(6f, () => { StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 10, Monster.monsterType.MON4)); }));
                StartCoroutine(WaitAndDo(7f, () => { StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 10, Monster.monsterType.MON5)); }));
                StartCoroutine(WaitAndDo(3f, () => {
                    StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 5, Monster.monsterType.MON6));
                    StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 5, Monster.monsterType.MON6));
                    StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 5, Monster.monsterType.MON6));
                }));
                StartCoroutine(WaitAndDo(10f, () => {
                    StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 5, Monster.monsterType.MON7));
                    StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 5, Monster.monsterType.MON7));
                    StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 5, Monster.monsterType.MON7));
                }));
                StartCoroutine(WaitAndDo(15f, () => {
                    StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 5, Monster.monsterType.MON8));
                    StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 5, Monster.monsterType.MON8));
                    StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 5, Monster.monsterType.MON8));
                }));

                StartCoroutine(WaitAndDo(3f, () => { StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 40, Monster.monsterType.MON6)); }));
                StartCoroutine(WaitAndDo(5f, () => { StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 40, Monster.monsterType.MON7)); }));
                StartCoroutine(WaitAndDo(7f, () => { StartCoroutine(CreateWave(MonsterSpawn.spawnDoor(getRamdomPos()), 50, Monster.monsterType.MON8)); }));


                break;
            case 18: spawning = true; break;
                /////////////
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
    IEnumerator CreateWave60s(Transform door, int amount, Monster.monsterType monsterType)
    {
        yield return new WaitForSeconds(3f);
        for (int i = 0; i < amount; i++)
        {
            yield return new WaitWhile(() => maxMonster != false);

            MonsterSpawn.spawnMonster(door.position, monsterType);
            yield return new WaitForSeconds(0.1f);
        }

        Destroy(door.gameObject);
        yield return new WaitForSeconds(60f);
        StartCoroutine(CreateWave60s(MonsterSpawn.spawnDoor(getRamdomPos()), 10, monsterType));
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
