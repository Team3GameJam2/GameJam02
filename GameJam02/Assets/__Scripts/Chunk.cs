using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chunk : MonoBehaviour
{
    [SerializeField]
    private int entryPoint;

    [SerializeField]
    private int exitPoint;

    [SerializeField]
    private int index;

    [SerializeField]
    private bool isTriggerForGen;

    public delegate void PlayerEnter();
    public PlayerEnter playerEnteredBuffer;

    public delegate void PlayerExit();
    public PlayerExit playerExitedBuffer;

    public int EntryPoint
    {
        get { return entryPoint; }

        set { entryPoint = value; }
    }

    public int ExitPoint
    {
        get { return exitPoint; }

        set { exitPoint = value; }
    }

    public int Index
    {
        get { return index; }

        set { index = value; }
    }

    public bool IsTriggerForGen
    {
        get { return isTriggerForGen; }

        set { isTriggerForGen = value; }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (isTriggerForGen)
        {
            if (playerEnteredBuffer != null)
            {
                playerEnteredBuffer();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (isTriggerForGen)
        {
            if (playerExitedBuffer != null)
            {
                playerExitedBuffer();
            }
        }
    }
}