using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class luckyboxOpen : MonoBehaviour
{
    public GameManeger gameManeger;
    public Transform mainPanel;
    public Image imagelight;
    public SpriteRenderer item;
    public Transform luckyBoxAnimator;
    public Transform itemAnimator;
    public Button okBTN;
    public Button cancelBTN;
    bool picked;
    bool take;
    Weapon weapon;

    public static luckyboxOpen Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    IEnumerator Roll()
    {
        List<Weapon> list = WeaponConntroller.getWeaponList();
        Weapon w;
        okBTN.gameObject.SetActive(false);
        cancelBTN.gameObject.SetActive(false);
        picked = false;
        take = false;
        gameManeger.gamePause(true);
        mainPanel.gameObject.SetActive(true);
        luckyBoxAnimator.gameObject.SetActive(true);
        imagelight.color = Color.white;
        item.sprite = null;
        yield return new WaitForSeconds(1f);
        itemAnimator.gameObject.SetActive(true);

        for (int i = 0;i < 11; i++)
        {
            w = getRamdomWeapon(Random.Range(0, list.Count), list);

            switch (w.rarityType)
            {
                case Rarity.rarityType.COMMON:
                    imagelight.color = Color.white;
                    break;
                case Rarity.rarityType.RARE:
                    imagelight.color = Color.blue;
                    break;
                case Rarity.rarityType.EPIC:
                    imagelight.color = Color.magenta;
                    break;
                case Rarity.rarityType.SUPERRARE:
                    imagelight.color = Color.yellow;
                    break;
            }

            weapon = WeaponConntroller.spawnWeapon(0, Vector2.zero, item.transform.position, w.weaponType);
            item.sprite = weapon.getSprite();

            if (i < 10 )
            {
                weapon.Destroythis();
                yield return new WaitForSeconds(0.3f);
            }
            else
            {
                okBTN.gameObject.SetActive(true);
                cancelBTN.gameObject.SetActive(true);
                yield return new WaitUntil(() => picked == true);
                if(take)
                {
                    gameManeger.player.inventory.addWeapon(w.weaponType);
                }
            }
        }
        if (weapon != null) weapon.Destroythis();
        mainPanel.gameObject.SetActive(false);
        itemAnimator.gameObject.SetActive(false);
        luckyBoxAnimator.gameObject.SetActive(false);
        gameManeger.gamePause(false);
        yield return 0;
    }

    public Weapon getRamdomWeapon(int i, List<Weapon> list)
    {
        return list[i];
    }

    public void okClicked()
    {
        picked = true;
        take = true;
    }

    public void cancelClicked()
    {
        picked = true;
        take = false;
    }

}
