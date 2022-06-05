using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkill : MonoBehaviour
{
    public Player player;
    public SkillUI skillUI;
    Transform target;
    float attackCoolDown;
    float countdown;
    Skill skillno1;
    Skill skillno2;
    Skill skillno3;

    void Start()
    {
        target = player.MouseAim;
        attackCoolDown = 0.5f;
        countdown = 1;
    }
    void Update()
    {
        if (attackCoolDown <= 0)
        {
            attackCoolDown = 0.5f;
        }
        attackCoolDown -= Time.deltaTime;

        if (countdown <= 0)
        {
            countdown = 0.5f;
            if (skillno1 != null)
            {
                if (skillno1.currentCoolDown != 0) skillno1.currentCoolDown--;
            }
            if (skillno2 != null)
            {
                if (skillno2.currentCoolDown != 0) skillno1.currentCoolDown--;
            }
            if (skillno3 != null)
            {
                if (skillno3.currentCoolDown != 0) skillno1.currentCoolDown--;
            }
        }
        countdown -= Time.deltaTime;


        if (skillno1 != null)
        {
            skillUI.setCoolDown1(skillno1);
        }
        if (skillno2 != null)
        {
            skillUI.setCoolDown1(skillno2);
        }
        if (skillno3 != null)
        {
            skillUI.setCoolDown1(skillno3);
        }
    }

    public void addSkill(Skill skill)
    {
        if(skillno1 == null)
        {
            skillno1 = skill;
            skillUI.setSkill1(skill);
        } 
        else if(skillno2 == null)
        {
            skillno2 = skill;
            skillUI.setSkill2(skill);
        }
        else if(skillno3 == null)
        {
            skillno3 = skill;
            skillUI.setSkill3(skill);
        }
    }

    public void skillNO1()
    { 
        if (skillno1 == null || attackCoolDown <= 0) return;
        if (skillno1.currentCoolDown != 0) return;

        attackCoolDown = 0.5f;
        useSkill(skillno1);
        skillno1.currentCoolDown = skillno1.coolDown;

    }

    public void skillNO2()
    {
        if (skillno2 == null) return;
        if (attackCoolDown <= 0)
        {
            attackCoolDown = 0.5f;
            useSkill(skillno2);
        }
    }

    public void skillNO3()
    {
        if (skillno3 == null) return;
        if (attackCoolDown <= 0)
        {
            attackCoolDown = 0.5f;
            useSkill(skillno3);
        }
    }

    public void useSkill(Skill skill)
    {
        switch(skill.skilltype)
        {
            case Skill.skillType.FIREBALL:
                lvl1fireball();
                break;
            case Skill.skillType.FIREPROTECTION:
                break;
        }
    }

    public void lvl1fireball()
    {
        Vector2 dir = (target.transform.position - player.transform.position).normalized;
        SkillController.spawnSkill(player.attack, dir, player.transform.position, Skill.skillType.FIREBALL);
    }
}
