using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class RightButton : EventTrigger
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
        player.SetMoveRight(true);
    }

    public override void OnPointerUp(PointerEventData data)
    {
        player.SetMoveRight(false);
    }
}