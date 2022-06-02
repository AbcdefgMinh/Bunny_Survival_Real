using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{

    public Player player;
    public Animator animator;
    // Start is called before the first frame update

    void Start()
    {
        
    }

    void Update()
    {
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
    }

    void FixedUpdate()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        //moving
        transform.Translate(new Vector3(x, y, 0) * Time.deltaTime * player.speed);
    }
}
