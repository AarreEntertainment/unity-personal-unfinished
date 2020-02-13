using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class returner : MonoBehaviour
{
    public int goal;
    void Start()
    {
        var objs = GameObject.FindObjectsOfType(typeof(GameObject));

        foreach(GameObject obj in objs)
        {
            if (obj.name.ToLower().Contains("pallet"))
            {
                goal++;
            }
        }
    }

    
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.root.name.ToLower().Contains("pallet")) {
            goal--;
            Destroy(other.transform.root.gameObject);
        }
        if (goal <= 0)
            Application.Quit();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
