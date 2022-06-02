using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    public List<Item> items;

    public static ItemController Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
        items = new List<Item>();
    }

    public static void spawnItem(Vector2 pos, Item.itemType itemType)
    {
        Instantiate(Instance.items.Find(x => x.itemtype == itemType), pos, Quaternion.identity);
    }

    public static Item getItem(Item.itemType itemType)
    {
        return Instance.items.Find(x => x.itemtype == itemType);
    }

    public static List<Item> getItemList ()
    {
        return Instance.items;
    }
}
