using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonWidth : MonoBehaviour
{

    private Canvas c;

    private RectTransform r;

    void Awake()
    {
        c = transform.root.GetComponent<Canvas>();
        r = GetComponent<RectTransform>();
        r.sizeDelta = new Vector2(Screen.width / 2, 0);
    }
}
