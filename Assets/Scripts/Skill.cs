using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


[Serializable]
public class Skill : Item
{

    public Skill() : base()
    {

    }

    public int lvl;
    public int damge;
    public int coolDown;
    public int cost;

}
