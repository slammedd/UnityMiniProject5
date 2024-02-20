using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    public GameObject[] tiles;
    public int numberOfTilesOnScreen;
    public Transform player;

    private float zSpawnLocation;


    // Start is called before the first frame update
    void Start()
    {
        for(int i =0; i < numberOfTilesOnScreen; i++)
        {
            if (i == 0) SpawnFirstTile();
            SpawnTile();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (player.position.z > zSpawnLocation - (numberOfTilesOnScreen * 32.5f))
        {
            SpawnTile();
        }
    }

    private void SpawnFirstTile()
    {
        Instantiate(tiles[0], transform.forward * zSpawnLocation, transform.rotation);
        zSpawnLocation += 32.5f;
    }

    private void SpawnTile()
    {
        Instantiate(tiles[Random.Range(0, tiles.Length)], transform.forward * zSpawnLocation, transform.rotation);
        zSpawnLocation += 32.5f;
    }
}
