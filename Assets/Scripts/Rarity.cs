using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class Rarity
{
    public enum rarityType
    {
        COMMON,
        RARE,
        EPIC,
        SUPERRARE
    }
    public rarityType raritytype;
}
