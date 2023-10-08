using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawn : MonoBehaviour
{
    // Start is called before the first frame update
    const float Coin_SpawnChance = 3f / 10f; // 30% chance
    const float BlueCoin_SpawnChance = 3f / 10f; // 30% chance
    public GameObject coinObject;
    public GameObject blueCoinObject;
    void Start()
    {
        if(Random.Range(0f, 1f) <= Coin_SpawnChance)
        {
            GameObject coinSpawnedObject = Instantiate(coinObject, transform.position + new Vector3(0, 1f, 0), Quaternion.Euler(0, 0, 0));
        } else if(Random.Range(0f, 1f) <= BlueCoin_SpawnChance)
        {
            GameObject coinSpawnedObject = Instantiate(blueCoinObject, transform.position + new Vector3(0, 1f, 0), Quaternion.Euler(0, 0, 0));
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
