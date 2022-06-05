using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillUI : MonoBehaviour
{
    public Slider slider1;
    public Slider slider2;
    public Slider slider3;
    public Image image1;
    public Image image2;
    public Image image3;

    public void setSkill1(Skill skill)
    {
        slider1.maxValue = skill.coolDown;
        slider1.value = skill.coolDown;
        image1.sprite = skill.spriteRenderer.sprite;
    }

    public void setCoolDown1(Skill skill)
    {
        slider1.value = skill.currentCoolDown;
    }

    public void setSkill2(Skill skill)
    {
        slider2.maxValue = skill.coolDown;
        slider2.value = skill.coolDown;
        image2.sprite = skill.spriteRenderer.sprite;
    }

    public void setCoolDown2(Skill skill)
    {
        slider2.value = skill.currentCoolDown;
    }

    public void setSkill3(Skill skill)
    {
        slider3.maxValue = skill.coolDown;
        slider3.value = skill.coolDown;
        image3.sprite = skill.spriteRenderer.sprite;
    }

    public void setCoolDown3(Skill skill)
    {
        slider3.value = skill.currentCoolDown;
    }
}
