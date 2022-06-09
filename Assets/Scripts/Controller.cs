using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{

    public Player player;
    public Animator animator;
    public bool enable = true;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Menu.Instance.PauseGame();
        }

        if (!enable) return;
 
        //set animation Up
        if (Input.GetKeyDown("w") || Input.GetKeyDown("up"))
        {
            animator.SetBool("IsUp", true);
        }
        else if (Input.GetKeyUp("w") || Input.GetKeyUp("up"))
        {
            animator.SetBool("IsUp", false);
        }
        //set animation Down
        if (Input.GetKeyDown("s") || Input.GetKeyDown("down"))
        {
            animator.SetBool("IsDown", true);
        }
        else if (Input.GetKeyUp("s") || Input.GetKeyUp("down"))
        {
            animator.SetBool("IsDown", false);
        }
        //set animation Left
        if (Input.GetKeyDown("a") || Input.GetKeyDown("left"))
        {
            animator.SetBool("IsLeft", true);
        }
        else if (Input.GetKeyUp("a") || Input.GetKeyUp("left"))
        {
            animator.SetBool("IsLeft", false);
        }
        //set animation Right
        if (Input.GetKeyDown("d") || Input.GetKeyDown("right"))
        {
            animator.SetBool("IsRight", true);
        }
        else if (Input.GetKeyUp("d") || Input.GetKeyUp("right"))
        {
            animator.SetBool("IsRight", false);
        }

        if (Input.GetKeyDown("q"))
        {
            player.playerSkill.skillNO1();
        }
        if (Input.GetKeyDown("e"))
        {
            player.playerSkill.skillNO2();
        }
        if (Input.GetKeyDown("r"))
        {
            player.playerSkill.skillNO3();
        }
    }

    void FixedUpdate()
    {
        if(!enable) return;

        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        //moving
        transform.Translate(new Vector3(x, y, 0) * Time.deltaTime * player.speed);
    }
}
