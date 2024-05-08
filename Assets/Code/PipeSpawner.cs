using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class PipeSpawner : MonoBehaviour
{
    public GameObject pipe;
    public float timer = 0;
    public float spawnInterval = 2;
    public float height = 10;

    // Start is called before the first frame update
    void Start()
    {
        GeneratePipe();
    }

    // Update is called once per frame
    void Update()
    {
        if (timer < spawnInterval)
        {
            timer += 1*Time.deltaTime;
        }
        else
        {
            GeneratePipe();
            timer = 0;
        }
    }

    void GeneratePipe()
    {
        float lowestPosition = transform.position.y - height;
        float highestPosition = transform.position.y + height;

        Instantiate(pipe, new Vector3(transform.position.x, Random.Range(lowestPosition, highestPosition), transform.position.z), transform.rotation);
    }
}
