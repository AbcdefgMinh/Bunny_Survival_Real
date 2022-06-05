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
    public int currentEXP;

    public void Update()
    {
        if (currentEXP != EXPSlider.value)
        {
            if(EXPSlider.value != EXPSlider.maxValue)
            {
                EXPSlider.value += 0.5f;
            }

            EXPanimator.SetBool("EXPGoing", true);
        }
        else
        {
            EXPanimator.SetBool("EXPGoing", false);

        }
    }

    public void setMaxEXP(int exp, int current ,int lvl)
    {
        EXPSlider.maxValue = exp;
        EXPSlider.value = 0;
        currentEXP = current;
        lvltxt.SetText("lvl " + lvl);
    }

   

    public void setMaxHP(float hp, float current)
    {
        EXPSlider.maxValue = hp;
        EXPSlider.value = current;
    }
    public void setMaxMP(float mp, float current)
    {
        EXPSlider.maxValue = mp;
        EXPSlider.value = current;
    }

    public void setEXP(int exp)
    {
        currentEXP += exp;
    }

    public void setHP(float hp)
    {
        if (HPSlider.value >= HPSlider.maxValue)
        {
            HPSlider.value = HPSlider.maxValue;
        }
        else
        {
            HPSlider.value += hp;
        }
       
    }

    public void setMP(float mp)
    {
        if(MPSlider.value >= MPSlider.maxValue)
        {
            MPSlider.value = MPSlider.maxValue;
        }
        else
        {
            MPSlider.value += mp;
        }
    }
   

}
