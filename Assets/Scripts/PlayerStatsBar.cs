using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatsBar : MonoBehaviour
{
    public Player player;
    public Slider EXPSlider;
    public Slider HPSlider;
    public Slider MPSlider;
    public Animator EXPanimator;
    public TextMeshProUGUI lvltxt;

    void Start()
    {
        setMaxEXP();
        setMaxHP();
        setMaxMP();
    }

    public void Update()
    {
        if (player.currentEXP != EXPSlider.value)
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

    public void setMaxEXP()
    {
        EXPSlider.maxValue = player.maxEXP;
        EXPSlider.value = player.currentEXP;
        lvltxt.SetText("lvl " + player.lvl);
    }

    public void setMaxHP()
    {
        EXPSlider.maxValue = player.maxEXP;
        EXPSlider.value = player.currentEXP;
    }
    public void setMaxMP()
    {
        EXPSlider.maxValue = player.maxEXP;
        EXPSlider.value = player.currentEXP;
    }


    public void setHP(int hp)
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

    public void setMP(int mp)
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
