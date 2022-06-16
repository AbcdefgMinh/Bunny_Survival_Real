using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponConntroller : MonoBehaviour
{
    
    public List<Weapon> weapons;

    public static WeaponConntroller Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
        weapons = new List<Weapon>();
        weapons.Add(transform.GetChild(0).GetComponent<Weapon>());
        weapons.Add(transform.GetChild(1).GetComponent<Weapon>());
        weapons.Add(transform.GetChild(2).GetComponent<Weapon>());
        weapons.Add(transform.GetChild(3).GetComponent<Weapon>());
        weapons.Add(transform.GetChild(4).GetComponent<Weapon>());
        weapons.Add(transform.GetChild(5).GetComponent<Weapon>());
    }

    public static Weapon spawnWeaponfly(float playerdamge,Vector2 dir,Vector2 pos, Weapon.WeaponType weaponType)
    {
        Weapon w = Instantiate(Instance.weapons.Find(x => x.weaponType == weaponType), pos, Quaternion.identity);
        w.setupfly(playerdamge,dir);
        return w;
    }

    public static Weapon spawnWeaponflyRamdom(float playerdamge, Vector2 pos, Weapon.WeaponType weaponType)
    {
        Weapon w = Instantiate(Instance.weapons.Find(x => x.weaponType == weaponType), pos, Quaternion.identity);
        w.setupfly(playerdamge,new Vector2(Random.Range(-1f,1f), Random.Range(-1f, 1f)));
        return w;
    }

    public static Weapon spawnWeaponfollow(Player player, Vector2 dir, Weapon.WeaponType weaponType)
    {
        Weapon w = Instantiate(Instance.weapons.Find(x => x.weaponType == weaponType), player.transform.position, Quaternion.identity);
        w.setupfollow(player, dir);
        return w;
    }

    public static Weapon spawnWeapon(float playerdamge, Vector2 dir, Vector2 pos, Weapon.WeaponType weaponType)
    {
        Weapon w = Instantiate(Instance.weapons.Find(x => x.weaponType == weaponType), pos, Quaternion.identity);
        w.setupangle(playerdamge, dir);
        return w;
    }

    public static Weapon getWeapon(Weapon.WeaponType weaponType)
    {
        return Instance.weapons.Find(x => x.weaponType == weaponType);
    }

    public static List<Weapon> getWeaponList()
    {
        return Instance.weapons;
    }
}
