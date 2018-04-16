using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField]
    private Chunk[] startChunkPrefabs;

    [SerializeField]
    private Chunk[] chunkPrefabs;

    [SerializeField]
    private Vector2Int chunkSize;

    [SerializeField]
    private int activeChunkLimit;

    [SerializeField]
    private int buffer;

    private List<Chunk> chunks;

    private int chunkCount;

    private void Awake()
    {
        chunks = new List<Chunk>();
        chunkCount = 0;
    }

    private void Start()
    {
        CreateStartChunk();
        CreateNextSet();
    }

    // Creates the first chunk
    private void CreateStartChunk()
    {
        Chunk chunk = Instantiate<Chunk>(startChunkPrefabs[Random.Range(0, startChunkPrefabs.Length)], new Vector3(0.0f, 0.0f), Quaternion.identity);
        chunk.Index = chunkCount;

        chunks.Add(chunk);
        chunkCount++;
    }

    private void CreateNextChunk()
    {
        Chunk nextChunk = GetNext(chunks[chunks.Count - 1]);

        if (nextChunk == null)
            Debug.LogWarning("NEXT CHUNK COULD NOT BE FOUND. EXIT POINT OF " + chunks[chunks.Count - 1].ExitPoint);

        Vector3 spawnPosition = new Vector3(0.0f, chunkCount * -chunkSize.y);

        Chunk chunk = Instantiate<Chunk>(nextChunk, spawnPosition, Quaternion.identity);
        chunk.Index = chunkCount;

        if (chunkCount % (activeChunkLimit - buffer) == 0)
        {
            chunk.IsTriggerForGen = true;
            chunk.playerEnteredBuffer += CreateNextSet;
            chunk.playerExitedBuffer += RemoveBufferChunk;
        }

        chunks.Add(chunk);
        chunkCount++;
    }

    private void DeleteChunks()
    {
        for (int i = 0; i < (activeChunkLimit - buffer) - 1; i++)
        {
            if (chunks[i].IsTriggerForGen)
            {
                chunks[i].playerEnteredBuffer -= CreateNextSet;
                chunks[i].playerExitedBuffer -= RemoveBufferChunk;
            }

            Destroy(chunks[i].gameObject);

        }

        chunks.RemoveRange(0, (activeChunkLimit - buffer) - 1);
    }

    private void RemoveBufferChunk()
    {
        Chunk removedChunk = chunks[0];
        chunks.RemoveAt(0);

        Destroy(removedChunk.gameObject);
    }

    // Generates x level of chunks ahead of the player.
    private void CreateNextSet()
    {
        if (chunks.Count > 1)
        {
            DeleteChunks();
        }

        for (int i = 0; i < activeChunkLimit; i++)
        {
            CreateNextChunk();
        }
    }

    private Chunk GetNext(Chunk current)
    {
        for (int i = 0; i < chunkPrefabs.Length; i++)
        {
            if (chunkPrefabs[i].EntryPoint == current.ExitPoint)
            {
                return chunkPrefabs[i];
            }
        }

        return null;
    }
}