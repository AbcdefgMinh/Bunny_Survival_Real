using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlCamera : MonoBehaviour
{
    public Transform Player;
    
    // Update is called once per frame
    void Update()
    {
        // moving camera follow player
        transform.position = new Vector3(Player.transform.position.x, Player.transform.position.y, -10);
    }
}
