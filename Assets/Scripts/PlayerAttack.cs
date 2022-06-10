using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Player player;
    Transform target;
    float attackCoolDown;

    void Start()
    {
        target = player.MouseAim;
        attackCoolDown = 0;
    }
    void Update()
    {
       if (GameManeger.pause) return;
       if(attackCoolDown <= 0)
       {
            attackCoolDown = player.attackSpeed;
            Attack();
       }
        attackCoolDown -= Time.deltaTime;
    }

    public void Attack()
    {
        if (GameManeger.pause) return;
        if (player.inventory.weaponList.Count == 0) return;
        foreach(Weapon weapon in player.inventory.weaponList)
        {
            switch (weapon.weaponType)
            {
                case Weapon.WeaponType.KNIFE:
                    lvl1knife();
                    break;

                default:
                    break;
            }
        }
    }
    private void lvl1knife()
    {  
        Vector2 dir = (target.transform.position - player.transform.position).normalized;

        WeaponConntroller.spawnWeapon(player.attack, dir, player.transform.position, Weapon.WeaponType.KNIFE);
    }

}
