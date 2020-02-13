using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bee : MonoBehaviour
{
    public Transform tgt;
    public void activate(Transform target)
    {
        tgt = target;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "x")
        {
            Destroy(transform.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (tgt != null)
        {
            if (Vector3.Distance(tgt.position, transform.position) < 20)
            {
                transform.LookAt(new Vector3(tgt.position.x, transform.position.y, tgt.position.z));
                transform.Translate(transform.forward * Time.deltaTime * 4);
                if(Vector3.Distance(tgt.position, transform.position) < 2)
                {
                    GetComponent<Animator>().SetTrigger("sting");
                }
            }

        }
        
    }
}
