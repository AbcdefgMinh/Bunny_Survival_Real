using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatsBar : MonoBehaviour
{
    public Slider EXPSlider;
    public Slider HPSlider;
    public Slider MPSlider;
    public Animator EXPanimator;
    public TextMeshProUGUI lvltxt;
    public int currentEXP = 0;

    public void Update()
    {
        if (currentEXP > 0)
        {
            if(EXPSlider.value == EXPSlider.maxValue)
            {
                EXPSlider.value = 0;            
            }
            else
            {
                EXPSlider.value += 1f;
                currentEXP -= 1;
            }

            EXPanimator.SetBool("EXPGoing", true);
        }
        else
        {
            EXPanimator.SetBool("EXPGoing", false);

        }
    }

    public void setMaxEXP(int exp , int lvl)
    {
        EXPSlider.maxValue = exp;
        lvltxt.SetText("lvl " + lvl);
    }

   

    public void setMaxHP(float hp, float current)
    {
        HPSlider.maxValue = hp;
        HPSlider.value = current;
    }
    public void setMaxMP(float mp, float current)
    {
        MPSlider.maxValue = mp;
        MPSlider.value = current;
    }

    public void setEXP(int exp)
    {
        currentEXP += exp;
    }

    public void setHP(float currentHP)
    {
        HPSlider.value = currentHP;
    }

    public void setMP(float currentMP)
    {
        MPSlider.value = currentMP;
    }
   

}
