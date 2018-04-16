using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonWidth : MonoBehaviour {

    public Canvas c;

    private RectTransform r;

    void Awake()
    {
        r = GetComponent<RectTransform>();
        r.sizeDelta = new Vector2(Screen.width/2, 0);
    }
}
