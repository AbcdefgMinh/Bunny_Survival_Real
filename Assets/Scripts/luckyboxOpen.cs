using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class luckyboxOpen : MonoBehaviour
{
    public Player player;
    public Animator luckybox;
    public Image light;
    public Image item;
    public Animator luckyBoxAnimator;
    public Animator itemAnimator;

    public LinkedList<Weapon> weaponsList;

    private void Start()
    {
        Roll();
    }
    void Update()
    {

    }

    IEnumerator Roll()
    {
        List<Weapon> list = WeaponConntroller.getWeaponList();
        Weapon w = getRamdomWeapon(Random.Range(0, list.Count - 1), list);
        for (int i = 0; i < 5; i++)
        {

            w = getRamdomWeapon(Random.Range(0, list.Count - 1), list);
            item.gameObject.SetActive(true);
            item.sprite = w.spriteRenderer.sprite;

            switch (w.rarityType)
            {
                case Rarity.rarityType.COMMON:
                    light.color = Color.white;
                    break;
                case Rarity.rarityType.RARE:
                    light.color = Color.blue;
                    break;
                case Rarity.rarityType.EPIC:
                    light.color = Color.magenta;
                    break;
                case Rarity.rarityType.SUPERRARE:
                    light.color = Color.yellow;
                    break;
            }

            yield return new WaitForSeconds(.1f);
        }

        if (player.inventory.weaponList.Contains(w))
        {

        }
        else
        {
            player.inventory.addWeapon(w);
        }


        yield return 0;
    }

    public Weapon getRamdomWeapon(int i, List<Weapon> list)
    {
        return list[i];
    }
}
