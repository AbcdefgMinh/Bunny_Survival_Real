using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class PlayerStats
{
    public enum playerStatType
    {
        MAXHP,
        MAXMP,
        ATTACK,
        ATTACKSPEED,
        SPEED,
    }

    public playerStatType playerstattype;
    public Sprite image;
    public Color color;
    public string description;
}
