using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeMenu : MonoBehaviour
{
    public Player player;
    public GameManeger gameManeger;
    public Transform panel;

    public UpgradeItemUI item1;
    public UpgradeItemUI item2;
    public UpgradeItemUI item3;
    public UpgradeItemUI item4;
    public List<PlayerStats> list;
    
    bool picked;

    public static UpgradeMenu Instance { get; private set; }

    private void Awake()
    {
        Instance = this; 
    }

    IEnumerator Roll()
    {
        picked = false;
        gameManeger.gamePause(true);
        panel.gameObject.SetActive(true);

        PlayerStats stat = null;
        item1.playerstats = null;
        item2.playerstats = null;
        item3.playerstats = null;
        item4.playerstats = null;

        for(int i = 0; i < 4; i++)
        {
            if (item1.playerstats != null && item2.playerstats != null && item3.playerstats != null && item4.playerstats != null) break;

            stat = getRamdomPlayerStats(Random.Range(0, list.Count));
            if (item1.playerstats == null)
            {
                item1.playerstats = stat;
                item1.statsName.text = stat.playerstattype.ToString();
                item1.description.text = stat.description;
                item1.icon.sprite = stat.image;
                item1.icon.color = stat.color;
                continue;
            }
            else
            {
                if (item1.playerstats == stat)
                {
                    i--;
                    continue;
                }
            }
            if (item2.playerstats == null)
            {
                item2.playerstats = stat;
                item2.statsName.text = stat.playerstattype.ToString();
                item2.description.text = stat.description;
                item2.icon.sprite = stat.image;
                item2.icon.color = stat.color;
                continue;
            }
            else
            {
                if (item2.playerstats == stat)
                {
                    i--;
                    continue;
                }
            }
            if (item3.playerstats == null)
            {
                item3.playerstats = stat;
                item3.statsName.text = stat.playerstattype.ToString();
                item3.description.text = stat.description;
                item3.icon.sprite = stat.image;
                item3.icon.color = stat.color;
                continue;
            }
            else
            {
                if (item3.playerstats == stat)
                {
                    i--;
                    continue;
                }
            }
            if (item4.playerstats == null)
            {
                item4.playerstats = stat;
                item4.statsName.text = stat.playerstattype.ToString();
                item4.description.text = stat.description;
                item4.icon.sprite = stat.image;
                item4.icon.color = stat.color;
            }
            else
            {
                if (item4.playerstats == stat)
                {
                    i--;
                    continue;
                }
            }
        }  

        yield return new WaitUntil(() => picked == true);

        panel.gameObject.SetActive(false);
        gameManeger.gamePause(false);
        yield return 0;
    }

    public PlayerStats getRamdomPlayerStats(int i)
    {
        return list[i];
    }

    public void addStats(PlayerStats playerStatType)
    {
        switch (playerStatType.playerstattype)
        {
            case PlayerStats.playerStatType.MAXHP:
                player.setMaxHP(30);
                break;
            case PlayerStats.playerStatType.MAXMP:
                player.setMaxMP(30); 
                break;
            case PlayerStats.playerStatType.SPEED:
                player.speed += 0.2f;
                break;
            case PlayerStats.playerStatType.ATTACK:
                player.attack += 0.5F;
                break;
            case PlayerStats.playerStatType.ATTACKSPEED:
                player.attackSpeed -= 0.1f;
                break;
        }
    }

    public void itemClicked(UpgradeItemUI u)
    {
        AudioManager.instance.Play(Sound.soundType.button);
        picked = true;
        addStats(u.playerstats);
    }

}
