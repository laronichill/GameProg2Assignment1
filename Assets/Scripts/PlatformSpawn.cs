using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr : MonoBehaviour
{
    // Start is called before the first frame update
    const float Coin_SpawnChance = 3f / 10f; // 40% chance
    public GameObject coinObject;
    void Start()
    {
        if(Random.Range(0f, 1f) <= Coin_SpawnChance)
        {
            GameObject coinSpawnedObject = Instantiate(coinObject, transform.position + new Vector3(0, 1f, 0), Quaternion.Euler(90, 0, 0));
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
