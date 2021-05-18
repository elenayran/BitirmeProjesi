using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightning : MonoBehaviour
{
    public GameObject lightinings;
    float randX;
    Vector2 WhereToSpawn;
    public float spawnRate = 2f;
    float nextSpawn = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextSpawn)
        {
            nextSpawn = Time.time + spawnRate;
            randX = Random.Range(113.57f, 150.9f);
            WhereToSpawn = new Vector2(randX, transform.position.y);
            Instantiate(lightinings, WhereToSpawn, Quaternion.identity);

        }

    }
}
