using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public Player player;
    public InventoryUI inventoryUI;
    public List<Item> itemList;
    public List<Weapon> weaponList;
    public List<Skill> skillList;


    void Start()
    {
        itemList = new List<Item>();
        weaponList = new List<Weapon>();
        skillList = new List<Skill>();
    }

    public void addWeapon(Weapon.WeaponType weaponType)
    {
        if (weaponList.Count == 4) return;
        Weapon w = WeaponConntroller.getWeapon(weaponType);
        foreach(Weapon weapon in weaponList)
        {
            if(weapon == w)
            {
                weapon.lvlUP();
                inventoryUI.updateUI();
                return;
            }
        }

        weaponList.Add(w);
        inventoryUI.updateUI();
    }

    public void addSkill(Skill.skillType skillType)
    {
        if (weaponList.Count == 3) return;
        skillList.Add(SkillController.getSkill(skillType));
        player.playerSkill.addSkill(SkillController.getSkill(skillType));
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
                    playerPickLuckyBox();
                    break;
            }

            item.Destroythis();
        }
        
    }

    private void playerPickEXP()
    {
        player.setEXP(20);
    }

    private void playerPickHealth()
    {
        player.setHP(40);
    }

    private void playerPickMana()
    {
        player.setMP(40);
    } 
    private void playerPickLuckyBox()
    {
        luckyboxOpen.Instance.StartCoroutine("Roll");
    }
}
