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
    internal void takeDamge(float damge)
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (attackCoolDown > 0)
        {
            attackCoolDown -= Time.deltaTime;
        }
        else
        {
              
        }

        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed*Time.deltaTime);
  
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
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
