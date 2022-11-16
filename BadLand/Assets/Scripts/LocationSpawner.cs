using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocationSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _finishWallPrefab;
    [SerializeField] Chunk[] ChunkPrefabs;
    [SerializeField] private List<Chunk> _spawnedChunks = new List<Chunk>();

    private void Start()
    {
        for (int i = 0; i < mover.lvlCounter + 1; i++)
        {
            chunkSpawn();
        }
        finishSpawn();
    }

    void Update()
    {
        
    }
    private void chunkSpawn()
    {
        Chunk newChank = Instantiate(ChunkPrefabs[ Random.Range(0, ChunkPrefabs.Length)]);
        newChank.transform.position = _spawnedChunks[_spawnedChunks.Count - 1]._endLvl.position - newChank._beginLvl.localPosition;
        _spawnedChunks.Add(newChank);  
    }
    private void finishSpawn()
    {
        Instantiate(_finishWallPrefab);
        _finishWallPrefab.transform.position = _spawnedChunks[_spawnedChunks.Count - 1]._endLvl.position ;
    }
}
 