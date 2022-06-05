using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeItemUI : MonoBehaviour
{
    public Text statsName;
    public Text description;
    public SpriteRenderer icon;
    public PlayerStats playerstats;

    void Awake()
    {
        statsName = transform.GetChild(2).GetComponent<Text>();
        description = transform.GetChild(3).GetComponent<Text>();
        icon = transform.GetChild(1).GetComponent<SpriteRenderer>();

    }
}
