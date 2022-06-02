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
    }

    public static void spawnWeapon(float playerdamge,Vector2 dir,Vector2 pos, Weapon.WeaponType weaponType)
    {
        Weapon w = Instantiate(Instance.weapons.Find(x => x.weaponType == weaponType), pos, Quaternion.identity);
        w.setup(playerdamge,dir);    
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
