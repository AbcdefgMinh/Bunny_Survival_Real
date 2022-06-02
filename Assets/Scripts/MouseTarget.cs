using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseTarget : MonoBehaviour
{
    public Camera cam;
    public Vector2 mousepos;

    private void FixedUpdate()
    {
        mousepos = cam.ScreenToWorldPoint(Input.mousePosition);
        transform.position = mousepos;
    }
}
