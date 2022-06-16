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

    public static luckyboxOpen Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    IEnumerator Roll()
    {
        List<Weapon> wlist = WeaponConntroller.getWeaponList();
        List<Skill> slist = SkillController.getSkillList();
        Weapon weapon;
        Skill skill;

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
        AudioManager.instance.PlayLoop(Sound.soundType.luckybox);
        for (int i = 0;i < 11; i++)
        {

            int what = Random.Range(0, 2);
            if(what == 1)
            {
                Weapon w = wlist[Random.Range(0, wlist.Count)];

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

                if (i < 10)
                {
                    weapon.Destroythis();
                    yield return new WaitForSeconds(0.2f);
                }
                else
                {
                    okBTN.gameObject.SetActive(true);
                    cancelBTN.gameObject.SetActive(true);
                    AudioManager.instance.Pause(Sound.soundType.luckybox);
                    yield return new WaitUntil(() => picked == true);
                    if (take)
                    {
                        gameManeger.player.inventory.addWeapon(w.weaponType);
                    }
                }
            }
            else
            {
                Skill s = slist[Random.Range(0, slist.Count)];

                switch (s.rarityType)
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

                skill = SkillController.getSkill(s.skilltype);
                item.sprite = s.getSprite();

                if (i < 10)
                {                 
                   yield return new WaitForSeconds(0.2f);
                    skill = null;
                    item.sprite = null;
                }
                else
                {
                    okBTN.gameObject.SetActive(true);
                    cancelBTN.gameObject.SetActive(true);
                    AudioManager.instance.Pause(Sound.soundType.luckybox);
                    yield return new WaitUntil(() => picked == true);
                    if (take)
                    {
                        gameManeger.player.inventory.addSkill(s.skilltype);
                        skill = null;
                        item.sprite = null;
                    }
                }
            }
           

            
        }
        AudioManager.instance.Pause(Sound.soundType.getitem);
        mainPanel.gameObject.SetActive(false);
        itemAnimator.gameObject.SetActive(false);
        luckyBoxAnimator.gameObject.SetActive(false);
        gameManeger.gamePause(false);
        yield return 0;
    }

    public void okClicked()
    {
        AudioManager.instance.Play(Sound.soundType.button);
        picked = true;
        take = true;
    }

    public void cancelClicked()
    {AudioManager.instance.Play(Sound.soundType.button);
        picked = true;
        take = false;
    }

}
