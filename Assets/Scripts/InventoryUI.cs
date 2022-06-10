using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
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
                Image image = item1.GetComponent<Image>();
                SpriteRenderer spriteRenderer = item1.GetComponentInChildren<SpriteRenderer>();
                TextMeshProUGUI text = item1.GetComponentInChildren<TextMeshProUGUI>();

                spriteRenderer.sprite = weapon.spriteRenderer.sprite;
                text.SetText("lvl: " + weapon.lvl);
                image.color = getColor(weapon.rarityType);
            }
            else if (item2 == null)
            {
                item2 = transform.GetChild(1).gameObject;
                item2.SetActive(true);
                Image image = item2.GetComponent<Image>();
                SpriteRenderer spriteRenderer = item2.GetComponentInChildren<SpriteRenderer>();
                TextMeshProUGUI text = item2.GetComponentInChildren<TextMeshProUGUI>();
                spriteRenderer.sprite = weapon.spriteRenderer.sprite;
                text.SetText("lvl: " + weapon.lvl);
                image.color = getColor(weapon.rarityType);
            }
            else if (item3 == null)
            {

                item3 = transform.GetChild(2).gameObject;
                item3.SetActive(true);
                Image image = item3.GetComponent<Image>();
                SpriteRenderer spriteRenderer = item3.GetComponentInChildren<SpriteRenderer>();
                TextMeshProUGUI text = item3.GetComponentInChildren<TextMeshProUGUI>();
                spriteRenderer.sprite = weapon.spriteRenderer.sprite;
                text.SetText("lvl: " + weapon.lvl);
                image.color = getColor(weapon.rarityType);
            }
            else if (item4 == null)
            {
                item4 = transform.GetChild(3).gameObject;
                item4.SetActive(true);
                Image image = item4.GetComponent<Image>();
                SpriteRenderer spriteRenderer = item4.GetComponentInChildren<SpriteRenderer>();
                TextMeshProUGUI text = item4.GetComponentInChildren<TextMeshProUGUI>();
                spriteRenderer.sprite = weapon.spriteRenderer.sprite;
                text.SetText("lvl: " + weapon.lvl);
                image.color = getColor(weapon.rarityType);
            }
        }
    }

    public Color getColor(Rarity.rarityType rarityType)
    {
        switch (rarityType)
        {
            case Rarity.rarityType.COMMON:
                return Color.white;
            case Rarity.rarityType.RARE:
                return Color.blue;
            case Rarity.rarityType.EPIC:
                return Color.magenta;
            case Rarity.rarityType.SUPERRARE:
                return Color.yellow;
            default:
                return Color.white;
        }
    }
}
