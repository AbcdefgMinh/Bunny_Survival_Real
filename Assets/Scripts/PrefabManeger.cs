using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabManeger : MonoBehaviour
{
    public static PrefabManeger Instance { get; private set; }

    private void Awake()
    {
        Instance = this;

        Instantiate(weapon).SetActive(false);
        Instantiate(item).SetActive(false);
        Instantiate(monster).SetActive(false);
        Instantiate(skill).SetActive(false);
        Instantiate(door).SetActive(false);
    }

    public GameObject weapon;
    public GameObject item;
    public GameObject monster;
    public GameObject skill;
    public GameObject door;

}
