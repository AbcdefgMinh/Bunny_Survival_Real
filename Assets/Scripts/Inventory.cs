using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public Player player;
    public List<Item> itemList;
    public List<Weapon> weaponList;
    public List<Skill> skillList;


    void Start()
    {
        itemList = new List<Item>();
        weaponList = new List<Weapon>();
        skillList = new List<Skill>();

        // addSkill(Skill.skillType.FIREBALL);
        // addSkill(Skill.skillType.EARTH);
        // addSkill(Skill.skillType.FIRESTORM);
        // addSkill(Skill.skillType.DARKNESS);

        

    }

    public void addWeapon(Weapon.WeaponType weaponType)
    {
        weaponList.Add(WeaponConntroller.getWeapon(weaponType));
    }

    public void addSkill(Skill.skillType skillType)
    {
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
