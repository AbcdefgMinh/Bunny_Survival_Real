using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawn : MonoBehaviour
{
    // Start is called before the first frame update
    public List<Monster> monsters;

    public static MonsterSpawn Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
        monsters = new List<Monster>();
    }

    public static void spawnMonster(Vector2 pos, Monster.monsterType monsterType)
    {
        GameManeger.monsters.Add(Instantiate(Instance.monsters.Find(x => x.monstertype == monsterType), pos, Quaternion.identity));
    }

    public static Transform spawnDoor(Vector2 pos)
    {
       return Instantiate(PrefabManeger.Instance.door, pos, Quaternion.identity).transform;
    }

    public static Monster getMonster(Monster.monsterType monsterType)
    {
        return Instance.monsters.Find(x => x.monstertype == monsterType);
    }

    public static List<Monster> getMonsterList()
    {
        return Instance.monsters;
    }
}
