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

    void Start()
    {
        controller.animator = animator;
        playerStatsBar.setMaxHP(maxHP,currentHP);
        playerStatsBar.setMaxMP(maxMP, currentMP);
        playerStatsBar.setMaxEXP(maxEXP, currentEXP,lvl);
    }
    internal void takeDamge(float damge)
    {
        currentHP -= damge;
        if(currentHP <= 0)
        {
            gamemaneger.EndGame();
        }

        setHP(-damge);
    }

    void FixedUpdate()
    {
        if (currentEXP >= maxEXP)
        {
            LvlUp();
        }
    }
    void LvlUp()
    {
        lvl++;
        currentEXP -= maxEXP;
        setMaxEXP(100);
        UpgradeMenu.Instance.StartCoroutine("Roll");
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
        playerStatsBar.setMaxEXP(maxEXP,currentEXP,lvl);
    }

    public void setEXP(int exp)
    {
        currentEXP += exp;
        playerStatsBar.setEXP(exp);
    }

    public void setHP(float hp)
    {
        currentHP += hp;
        playerStatsBar.setHP(hp);
    }

    public void setMP(float mp)
    {
        currentMP += mp;
        playerStatsBar.setHP(mp);
    }
}
