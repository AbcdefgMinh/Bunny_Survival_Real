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

    // player stats
    public float lvl;
    public float currentEXP;
    public float maxEXP;
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
    }
    internal void takeDamge(float damge)
    {
    }
    void Update()
    {

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
        maxEXP += 100;
        playerStatsBar.setMaxEXP();
    }
}
