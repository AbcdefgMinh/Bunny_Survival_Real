using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DamgePopUp : MonoBehaviour
{
    public static DamgePopUp Instance { get; private set; }

    public GameObject popup;

    void Awake()
    {
        Instance = this;
        popup = transform.GetChild(0).gameObject;
        
    }

    public void spawnPopUp(int damge,Vector2 pos)
    {
        GameObject ob = Instantiate(popup, pos, Quaternion.identity,transform);
        ob.GetComponent<PopUp>().setup(damge);
    }
}
