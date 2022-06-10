using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PopUp : MonoBehaviour
{
    public TextMeshProUGUI text;

    public void setup(int damge)
    {
        text.SetText(damge.ToString());
        Destroy(gameObject, 3f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.up * Time.deltaTime);
        text.fontSize -= Time.deltaTime * 5f;
    }
}
