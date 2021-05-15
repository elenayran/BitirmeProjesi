using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boulder : MonoBehaviour
{
    public GameObject boulders;
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
            randX = Random.Range(68.14f, 75.07f);
            WhereToSpawn = new Vector2(randX, transform.position.y);
            Instantiate(boulders, WhereToSpawn, Quaternion.identity);

        }
        
    }
}
