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
                    if(weapon.lvl == 1)
                    {
                        knifelvl1();
                    }
                    else if(weapon.lvl == 2)
                    {
                        knifelvl2();
                    }
                    else if (weapon.lvl == 3)
                    {
                        knifelvl3();
                    }

                    break;
                case Weapon.WeaponType.SWORD:
                    if (weapon.lvl == 1)
                    {
                        swordlvl1();
                    }
                    else if (weapon.lvl == 2)
                    {
                        swordlvl2();
                    }
                    else if (weapon.lvl == 3)
                    {
                        swordlvl3();
                    }
                    break;
                case Weapon.WeaponType.SPEAR:
                    if (weapon.lvl == 1)
                    {
                        spearlvl1();
                    }
                    else if (weapon.lvl == 2)
                    {
                        spearlvl2();
                    }
                    else if (weapon.lvl == 3)
                    {
                        spearlvl3();
                    }
                    break;
                case Weapon.WeaponType.SCYTHE:
                    if (weapon.lvl == 1)
                    {
                        scythelvl1();
                    }
                    else if (weapon.lvl == 2)
                    {
                        scythelvl2();
                    }
                    else if (weapon.lvl == 3)
                    {
                        scythelvl3();
                    }
                    break;
                case Weapon.WeaponType.DEMONSWORD:
                    if (weapon.lvl == 1)
                    {
                        demonswordlvl1();
                    }
                    else if (weapon.lvl == 2)
                    {
                        demonswordlvl2();
                    }
                    else if (weapon.lvl == 3)
                    {
                        demonswordlvl3();
                    }
                    break;
                case Weapon.WeaponType.HAMMER:
                    if (weapon.lvl == 1)
                    {
                        hammerlvl1();
                    }
                    else if (weapon.lvl == 2)
                    {
                        hammerlvl2();
                    }
                    else if (weapon.lvl == 3)
                    {
                        hammerlvl3();
                    }
                    break;
                default:
                    break;
            }
        }
    }
    void knifelvl1()
    {  
        Vector2 dir = (target.transform.position - player.transform.position).normalized;

        WeaponConntroller.spawnWeaponfly(player.attack, dir, player.transform.position, Weapon.WeaponType.KNIFE);
    }

    void knifelvl2()
    {
        Vector2 dir = (target.transform.position - player.transform.position).normalized;

        WeaponConntroller.spawnWeaponfly(player.attack, dir , player.transform.position, Weapon.WeaponType.KNIFE);
        WeaponConntroller.spawnWeaponflyRamdom(player.attack, player.transform.position, Weapon.WeaponType.KNIFE);
    }
    void knifelvl3()
    {
        Vector2 dir = (target.transform.position - player.transform.position).normalized;
        WeaponConntroller.spawnWeaponfly(player.attack, dir + new Vector2(0.5f, 0), player.transform.position, Weapon.WeaponType.KNIFE);
        WeaponConntroller.spawnWeaponflyRamdom(player.attack, player.transform.position, Weapon.WeaponType.KNIFE);
        WeaponConntroller.spawnWeaponflyRamdom(player.attack, player.transform.position, Weapon.WeaponType.KNIFE);
        WeaponConntroller.spawnWeaponflyRamdom(player.attack, player.transform.position, Weapon.WeaponType.KNIFE);
    }

    void hammerlvl1()
    {
        Vector2 dir = (target.transform.position - player.transform.position).normalized;

        WeaponConntroller.spawnWeaponfollow(player, dir , Weapon.WeaponType.HAMMER);
    }

    void hammerlvl2()
    {
        Vector2 dir = (target.transform.position - player.transform.position).normalized;

        Weapon w = WeaponConntroller.spawnWeaponfollow(player, dir, Weapon.WeaponType.HAMMER);
        w.transform.localScale = new Vector2(2f, 2.5f);
    }

    void hammerlvl3()
    {
        Vector2 dir = (target.transform.position - player.transform.position).normalized;

        Weapon w = WeaponConntroller.spawnWeaponfollow(player, dir, Weapon.WeaponType.HAMMER);
        w.transform.localScale = new Vector2(2.5f, 3f);
    }

    void swordlvl1()
    {
        Vector2 dir = (target.transform.position - player.transform.position).normalized;

        WeaponConntroller.spawnWeaponfly(player.attack, dir, player.transform.position, Weapon.WeaponType.SWORD);
    }
    void swordlvl2()
    {
        Vector2 dir = (target.transform.position - player.transform.position).normalized;

        WeaponConntroller.spawnWeaponfly(player.attack, dir, player.transform.position, Weapon.WeaponType.SWORD);
        WeaponConntroller.spawnWeaponfly(player.attack, -dir, player.transform.position, Weapon.WeaponType.SWORD);
    }

    void swordlvl3()
    {
        Vector2 dir = (target.transform.position - player.transform.position).normalized;

        WeaponConntroller.spawnWeaponfly(player.attack, dir, player.transform.position, Weapon.WeaponType.SWORD);
        WeaponConntroller.spawnWeaponfly(player.attack, -dir, player.transform.position, Weapon.WeaponType.SWORD);
        WeaponConntroller.spawnWeaponfly(player.attack, dir + Vector2.up, player.transform.position, Weapon.WeaponType.SWORD);
        WeaponConntroller.spawnWeaponfly(player.attack, dir + Vector2.down, player.transform.position, Weapon.WeaponType.SWORD);
    }

    void scythelvl1()
    {
        WeaponConntroller.spawnWeaponflyRamdom(player.attack, player.transform.position, Weapon.WeaponType.SCYTHE);
    }

    void scythelvl2()
    {
        WeaponConntroller.spawnWeaponflyRamdom(player.attack, player.transform.position, Weapon.WeaponType.SCYTHE);
        WeaponConntroller.spawnWeaponflyRamdom(player.attack, player.transform.position, Weapon.WeaponType.SCYTHE);
    }

    void scythelvl3()
    {
        WeaponConntroller.spawnWeaponflyRamdom(player.attack, player.transform.position, Weapon.WeaponType.SCYTHE);
        WeaponConntroller.spawnWeaponflyRamdom(player.attack, player.transform.position, Weapon.WeaponType.SCYTHE);
        WeaponConntroller.spawnWeaponflyRamdom(player.attack, player.transform.position, Weapon.WeaponType.SCYTHE);
    }
    void spearlvl1()
    {
        Vector2 dir = (target.transform.position - player.transform.position).normalized;
        WeaponConntroller.spawnWeaponflyRamdom(player.attack, player.transform.position, Weapon.WeaponType.SPEAR);
    }
    void spearlvl2()
    {
        Vector2 dir = (target.transform.position - player.transform.position).normalized;

        WeaponConntroller.spawnWeaponflyRamdom(player.attack, player.transform.position, Weapon.WeaponType.SPEAR);
        WeaponConntroller.spawnWeaponflyRamdom(player.attack, player.transform.position, Weapon.WeaponType.SPEAR);

    }
    void spearlvl3()
    {
        Vector2 dir = (target.transform.position - player.transform.position).normalized;

        WeaponConntroller.spawnWeaponflyRamdom(player.attack, player.transform.position, Weapon.WeaponType.SPEAR);
        WeaponConntroller.spawnWeaponflyRamdom(player.attack, player.transform.position, Weapon.WeaponType.SPEAR);
        WeaponConntroller.spawnWeaponflyRamdom(player.attack, player.transform.position, Weapon.WeaponType.SPEAR);
    }

    void demonswordlvl1()
    {
        Vector2 dir = (target.transform.position - player.transform.position).normalized;

        WeaponConntroller.spawnWeaponfly(player.attack, dir, player.transform.position, Weapon.WeaponType.DEMONSWORD);
    }

    void demonswordlvl2()
    {
        Vector2 dir = (target.transform.position - player.transform.position).normalized;

        WeaponConntroller.spawnWeaponfly(player.attack + 3, dir, player.transform.position, Weapon.WeaponType.DEMONSWORD);
    }

    void demonswordlvl3()
    {
        Vector2 dir = (target.transform.position - player.transform.position).normalized;

        WeaponConntroller.spawnWeaponfly(player.attack + 5, dir, player.transform.position, Weapon.WeaponType.DEMONSWORD);
    }


}
