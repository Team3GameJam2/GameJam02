using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class LeftButton : EventTrigger
{
    private _Movement player;

    [SerializeField]
    public bool right;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<_Movement>();
    }

    public override void OnPointerDown(PointerEventData data)
    {
        player.SetMoveLeft(true);
    }

    public override void OnPointerUp(PointerEventData data)
    {
        player.SetMoveLeft(false);
    }
}