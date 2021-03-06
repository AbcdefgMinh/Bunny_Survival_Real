using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //plyer commpoment
    public BoxCollider2D boxCollider;
    Vector3 moveDelta;
    RaycastHit2D hit;
    public Animator animator;
    public Transform MouseAim;

    //player stuff
    public Inventory inventory;
    public Controller controller;
    public PlayerStatsBar playerStatsBar;
    public PlayerSkill playerSkill;
    public GameManeger gamemaneger;

    // player stats
    public int lvl;
    public int currentEXP;
    public int maxEXP;
    public float currentHP;
    public float maxHP;
    public float currentMP;
    public float maxMP;

    public float pickUPRadius;
    public float attack;
    public float attackSpeed;
    public float speed = 1.5f;

    float CoolDown = 1;

    void Start()
    {
        controller.animator = animator;
        playerStatsBar.setMaxHP(maxHP,currentHP);
        playerStatsBar.setMaxMP(maxMP, currentMP);
        playerStatsBar.setMaxEXP(maxEXP,lvl);
    }
    private void Update()
    {
        if (GameManeger.pause) return;
        if (CoolDown <= 0)
        {
            CoolDown = 1;
            setHP(1);
            setMP(1);
        }
        CoolDown -= Time.deltaTime;
    }
    internal void takeDamge(float damge)
    {
        if(currentHP <= 0)
        {
            gamemaneger.EndGame();
        }

        setHP(-damge);
    }

    public void setMaxHP(int max)
    {
        maxHP += max;
        if (currentHP + max >= maxHP) currentHP = maxHP;
        else currentHP += max;

        playerStatsBar.setMaxHP(maxHP,currentHP);
    }

    public void setMaxMP(int max)
    {

        maxMP += max;
        if (currentMP + max >= maxHP) currentMP = maxMP;
        else currentMP += max;

        playerStatsBar.setMaxMP(maxMP,currentEXP);

    }

    public void setMaxEXP(int max)
    {
        maxEXP += max;
        playerStatsBar.setMaxEXP(maxEXP,lvl);
    }

    public void setEXP(int exp)
    {
        
        currentEXP += exp;
        if (currentEXP >= maxEXP)
        {
            lvl++;
            currentEXP -= maxEXP;
            setMaxEXP(100);
            UpgradeMenu.Instance.StartCoroutine("Roll");
        }
        playerStatsBar.setEXP(exp);
    }

    public void setHP(float hp)
    {
        currentHP += hp;
        if (currentHP > maxHP) currentHP = maxHP;
        playerStatsBar.setHP(currentHP);
    }

    public void setMP(float mp)
    {
        currentMP += mp;
        if (currentMP > maxMP) currentMP = maxMP;
        playerStatsBar.setMP(currentMP);
    }
}
