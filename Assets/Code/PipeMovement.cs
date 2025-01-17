using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeMovement : MonoBehaviour
{
    public float pipeSpeed = 5;
    private float deadZone = -40;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += (Vector3.left * pipeSpeed * Time.deltaTime);

        if (transform.position.x <= deadZone)
        {
            Destroy(gameObject);
        }
    }
}
