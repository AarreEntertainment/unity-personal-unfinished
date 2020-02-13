using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damageable : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.GetComponent<DamageReferrer>() != null)
        {
            Vector3 dir = collision.collider.GetComponent<DamageReferrer>().dp.centerOfMass.GetComponent<Rigidbody>().velocity;

            GetComponent<Rigidbody>().AddForce((dir +Vector3.up)* collision.collider.GetComponent<DamageReferrer>().dp.damage, ForceMode.Impulse);
            Debug.Log("enter");
            if (collision.collider.transform.root.GetComponent<Rigidbody>() != null)
            {
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
