using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public enum WeaponType
    {
        KNIFE,
        SWORD,
        DEMONSWORD,
        HAMMER,
        SPEAR,
        SCYTHE
    }

    public Rigidbody2D rb2d;
    public SpriteRenderer spriteRenderer;


    public WeaponType weaponType;
    public int lvl;
    public float damge;
    public float speed;
    public float knockBack;
    public float timeOnField;
    public Rarity.rarityType rarityType;
    Player player;
    bool follow = false;

     void Update()
     {
        if(follow)
        {
            if(player != null)
            {
                transform.position = player.transform.position;
            }
        }
     }

    public void lvlUP()
    {
        if (lvl == 3) return;
        lvl++;    
    }

    public void setupfly(float playerdamge,Vector2 dir)
    {
        this.damge += playerdamge;
        float angle = Mathf.Atan2(dir.x, dir.y) * Mathf.Rad2Deg;
        transform.eulerAngles = new Vector3(0, 0, -angle);
        rb2d.AddForce(dir * speed, ForceMode2D.Impulse);
        Destroy(gameObject,timeOnField);
    }

    public void setupangle(float playerdamge, Vector2 dir)
    {
        this.damge += playerdamge;
        float angle = Mathf.Atan2(dir.x, dir.y) * Mathf.Rad2Deg;
        transform.eulerAngles = new Vector3(0, 0, -angle);
        Destroy(gameObject, timeOnField);
    }

    public void setupfollow(Player player, Vector2 dir)
    {
        this.damge += player.attack;
        float angle = Mathf.Atan2(dir.x, dir.y) * Mathf.Rad2Deg;
        transform.eulerAngles = new Vector3(0, 0, -angle);
        this.player = player;
        follow = true;
        Destroy(gameObject, timeOnField);
    }

    public void Destroythis()
    {
        Destroy(gameObject);
    }

    public Sprite getSprite()
    {
        return spriteRenderer.sprite;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Monster monster = collision.transform.GetComponent<Monster>();
        if(monster != null)
        {
            monster.takeDamge(damge);
        }
    }
}
