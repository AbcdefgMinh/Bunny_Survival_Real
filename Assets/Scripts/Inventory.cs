using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public Player player;
    public List<Item> itemList;
    public List<Weapon> weaponList;
    

    void Start()
    {
        itemList = new List<Item>();
        weaponList = new List<Weapon>();

        weaponList.Add(WeaponConntroller.getWeapon(Weapon.WeaponType.KNIFE));
    }
    public void addItem(Item item)
    {
        foreach(Item i in itemList)
        {
            if (i == item)
            {
            }
        }

        itemList.Add(item);
    }
    public void addWeapon(Weapon weapon)
    {
        weaponList.Add(weapon);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        Item item = collider.transform.GetComponent<Item>();
        if(item != null)
        {
            switch (item.itemtype)
            {
                case Item.itemType.EXP:
                    playerPickEXP();
                    break;
                case Item.itemType.HEALTHPOTION:
                    playerPickHealth();
                    break;
                case Item.itemType.MANAPOTION:
                    playerPickMana();
                    break;
                case Item.itemType.LUCKYBOX:
                    break;
            }

            item.Destroythis();
        }
        
    }

    private void playerPickEXP()
    {
        player.currentEXP += 20;
    }

    private void playerPickHealth()
    {
        player.currentHP += 40;
        player.playerStatsBar.setHP(40);
    }

    private void playerPickMana()
    {
        player.currentMP += 40;
        player.playerStatsBar.setMP(40);

    } 
}
