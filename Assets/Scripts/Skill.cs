using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill : MonoBehaviour
{

    public enum skillType
    {
        FIREBALL,
        FIREPROTECTION,

    }

    public Rigidbody2D rb2d;
    public SpriteRenderer spriteRenderer;
    public Animator animator;

    public void Awake()
    {
        SkillController.Instance.skills.Add(this);
    }

   
    public int lvl;
    public float damge;
    public float speed;
    public int coolDown;
    public int currentCoolDown;
    public int cost;
    public float knockBack;
    public float timeOnField;
    public skillType skilltype;
    public Rarity.rarityType rarityType;

    public void setup(float playerdamge, Vector2 dir)
    {
        this.damge += playerdamge;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.eulerAngles = new Vector3(0, 0, angle);
        rb2d.AddForce(dir * speed, ForceMode2D.Impulse);

        StartCoroutine("DestroyWithAnimation");
    }

    IEnumerator DestroyWithAnimation()
    {

        yield return new WaitForSeconds(timeOnField);
        animator.SetTrigger("End");
        yield return new WaitForSeconds(3f);
        Destroy(gameObject);
        yield return null;
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

    }
}
