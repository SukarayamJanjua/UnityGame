using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvManager : MonoBehaviour
{
    public GameObject[] terrainPrefabs;
    public Transform playerTransform;
    public float spawnZ = 0f;
    public float terrainLength = 300f;
    private int amnterrainOnScreen = 2;

    public List<GameObject> activeTerrains;
    public float safeZone = 340f;
    //public Transform positionTerrain;
    // Start is called before the first frame update
    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        activeTerrains = new List<GameObject>();
        for (int i = 0; i < amnterrainOnScreen; i++) 
        {
            SpawnTerrain();
        }
        
        
    }

    // Update is called once per frame
    void Update()
    {
        if (playerTransform.position.z -safeZone> (spawnZ - amnterrainOnScreen * terrainLength)){
            SpawnTerrain();
            DeleteTerrain();
        }
    }
    void SpawnTerrain( int prefabIndex = -1)
    {
        GameObject go;
        go = Instantiate(terrainPrefabs[0]) as GameObject ;
        go.transform.SetParent(transform);
        go.transform.position = Vector3.forward * spawnZ;
        spawnZ += terrainLength;

        activeTerrains.Add(go);
    }
    void DeleteTerrain()
    {
        Destroy(activeTerrains[0]);
        activeTerrains.RemoveAt(0);
    }
}
