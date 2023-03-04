using System.Collections;
using System.Collections.Generic;//to use lists in C#
using UnityEngine;


public class TileManager : MonoBehaviour
{
    public GameObject[] tilePrefabs;
    public Transform playerTransform;
   
    public float spawnZ = -8f;
    public float tileLength = 16f;
    public int amnTilesOnScreen = 7;

    public List<GameObject> activeTiles;
    public float safeZone = 16f;

    public int lastPrefabIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        activeTiles = new List<GameObject>();

        for(int i = 0; i < amnTilesOnScreen; i++)
        {
            if (i < 3)
            {
                SpawnTiles(0);

            }
            else
            {
                SpawnTiles();
            }
           
        }
        //SpawnTiles();
    }

    // Update is called once per frame
    void Update()
    {
        if(playerTransform.position.z - safeZone> (spawnZ-amnTilesOnScreen * tileLength))
        {
            SpawnTiles();
            DeleteTiles();
        }
    }
    void SpawnTiles(int prefabIndex = -1)
    {
        GameObject go;
        if(prefabIndex == -1)
        {
            go = Instantiate(tilePrefabs[RandomPrefabIndex()]) as GameObject;
        }
        else
        {
            go = Instantiate(tilePrefabs[prefabIndex]) as GameObject;
        }
        
        go.transform.SetParent(transform);
        go.transform.position = Vector3.forward * spawnZ;
        spawnZ += tileLength;

        activeTiles.Add(go);
    }
    void DeleteTiles()
    {
        Destroy(activeTiles[0]);
        activeTiles.RemoveAt(0);
    }

    //Random spawning of tiles
    private int RandomPrefabIndex()
    {
        if(tilePrefabs.Length <= 1)
        {
            return 0;
        }
        int randonIndex = lastPrefabIndex;
        while(randonIndex == lastPrefabIndex)
        {
            randonIndex = Random.Range(0,tilePrefabs.Length);
        }
        lastPrefabIndex = randonIndex;
        return randonIndex;
    }
    //void SpawnInvisibleBorders()
    //{
        
    //}
}
