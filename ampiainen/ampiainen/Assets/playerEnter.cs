using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerEnter : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Player")
        {

            foreach (GameObject b in transform.parent.GetComponent<plate>().bees)
            {
                b.GetComponent<bee>().tgt = collision.collider.transform;
            }
        }
    }
}
