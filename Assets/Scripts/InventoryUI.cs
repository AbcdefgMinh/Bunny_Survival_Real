using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InventoryUI : MonoBehaviour
{
    public Player player;
    GameObject item1;
    GameObject item2;
    GameObject item3;
    GameObject item4;

    public void updateUI()
    {
        List<Weapon> weapons = player.inventory.weaponList;
        item1 = null;
        item2 = null;
        item3 = null;
        item4 = null;
        foreach (Weapon weapon in weapons)
        {
            if (item1 == null)
            {
                item1 = transform.GetChild(0).gameObject;
                item1.SetActive(true);
                SpriteRenderer spriteRenderer = item1.GetComponentInChildren<SpriteRenderer>();
                TextMeshProUGUI text = item1.GetComponentInChildren<TextMeshProUGUI>();
                spriteRenderer.sprite = weapon.spriteRenderer.sprite;
                text.SetText("lvl: " + weapon.lvl);
            }
            else if (item2 == null)
            {
                item2 = transform.GetChild(1).gameObject;
                item2.SetActive(true);
                SpriteRenderer spriteRenderer = item2.GetComponentInChildren<SpriteRenderer>();
                TextMeshProUGUI text = item2.GetComponentInChildren<TextMeshProUGUI>();
                spriteRenderer.sprite = weapon.spriteRenderer.sprite;
                text.SetText("lvl: " + weapon.lvl);
            }
            else if (item3 == null)
            {

                item3 = transform.GetChild(2).gameObject;
                item3.SetActive(true);
                SpriteRenderer spriteRenderer = item3.GetComponentInChildren<SpriteRenderer>();
                TextMeshProUGUI text = item3.GetComponentInChildren<TextMeshProUGUI>();
                spriteRenderer.sprite = weapon.spriteRenderer.sprite;
                text.SetText("lvl: " + weapon.lvl);
            }
            else if (item4 == null)
            {
                item4 = transform.GetChild(3).gameObject;
                item4.SetActive(true);
                SpriteRenderer spriteRenderer = item4.GetComponentInChildren<SpriteRenderer>();
                TextMeshProUGUI text = item4.GetComponentInChildren<TextMeshProUGUI>();
                spriteRenderer.sprite = weapon.spriteRenderer.sprite;
                text.SetText("lvl: " + weapon.lvl);
            }
        }
    }
}
