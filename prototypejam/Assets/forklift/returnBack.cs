using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class returnBack : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -40)
        {
            transform.position = Vector3.zero + Vector3.up;
        }
    }
}
