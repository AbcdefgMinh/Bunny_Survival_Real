using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    // Start is called before the first frame update
    public CircleCollider2D circleCollider;

    Player player;
    public float lvl;
    public float maxHP;
    public float attack;
    public float speed;
    public float attackCoolDown;
    public monsterType monstertype;
    public enum monsterType
    {
        MON1,
        MON2,
        MON3,
        MON4,
        MON5,
        MON6,
        MON7,
        MON8
    }

    void Awake()
    {

        MonsterSpawn.Instance.monsters.Add(this);

        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        }
    }

    void Start()
    {
        attackCoolDown = 0.5F;
        
        
    }
    public void takeDamge(float damge)
    {
        maxHP -= damge;
        DamgePopUp.Instance.spawnPopUp((int)damge, transform.position);
        GameManeger.DAMGEDEAL += (int)damge;
        if (maxHP <= 0) Monsterdie();
    }

    public void Monsterdie()
    {
        GameManeger.monsters.Remove(this);
        GameManeger.MONSTERSKILL++;


        int i = Random.Range(0, 101);
  
        if(i == 100)
        {
            ItemController.spawnItem(transform.position, Item.itemType.LUCKYBOX);
        }
        else if(i >= 97 && i <= 99)
        {
            ItemController.spawnItem(transform.position, Item.itemType.HEALTHPOTION);
        }
        else if(i >= 93 && i <= 96)
        {
            ItemController.spawnItem(transform.position, Item.itemType.MANAPOTION);
        }
        else if(i < 92)
        {
            ItemController.spawnItem(transform.position, Item.itemType.EXP);
        }

        Destroy(gameObject);
    }    

    // Update is called once per frame
    void Update()
    {
        if (GameManeger.pause) return;
        if (attackCoolDown > 0)
        {
            attackCoolDown -= Time.deltaTime;
        }

        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed*Time.deltaTime);

    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        Player player = collision.gameObject.GetComponent<Player>();
        if (player != null)
        {
            if (attackCoolDown < 0)
            {
                player.takeDamge(attack);
                attackCoolDown = 0.5f;
            }
        }
    }

 
}
