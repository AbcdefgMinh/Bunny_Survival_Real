using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Item : MonoBehaviour
{
    public void Awake()
    {
        ItemController.Instance.items.Add(this);
    }

    public enum itemType
    {
        //ITEM
        EXP,
        HEALTHPOTION,
        MANAPOTION,
        LUCKYBOX,
    }

    public itemType itemtype;
    public Rarity.rarityType rarity;
    public string dedescription;

    public void Destroythis()
    {
        Destroy(gameObject);
    }
}
