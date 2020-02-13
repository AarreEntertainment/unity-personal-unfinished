using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plate : MonoBehaviour
{
    public int index;
    public GameObject bee;
    public GameObject plateModel;
    public List<GameObject> bees;
    public GameObject[] foliage;
    public float x;
    public float z;
    Vector3 zero;
    // Start is called before the first frame update
    void Start()
    {
        zero = transform.position - new Vector3(x / 2, 0, z / 2);
        createFoliageAndBees();
        if (index < 20)
        {
            GameObject plate = Instantiate(plateModel);
            Vector3 dir = Vector3.zero;
            switch (Random.Range(0, 3))
            {
                case 0:
                    dir = Vector3.right;
                    break;

                case 1:
                    dir = Vector3.left;
                    break;

                case 2:
                    dir = Vector3.forward;
                    break;

                case 3:
                    dir = Vector3.back;
                    break;
            }
            plate.transform.position = transform.position + (dir * Random.Range(10, 30)) + Vector3.up*5;
            plate.GetComponent<plate>().index = index + 1;
            
        }
    }
    void createFoliageAndBees()
    {
        int v = Mathf.RoundToInt(30 * Random.value);

        for(int i = 0; i < v; i++)
        {
            RaycastHit hit;
            if(Physics.Raycast(zero+new Vector3 (Random.value*x, 1, Random.value*z), Vector3.down, out hit, 1.4f))
            {
                GameObject f = Instantiate(foliage[Random.Range(0, foliage.Length - 1)], transform);
                f.transform.position = hit.point;
                //Debug.Log("bl");
            }
        }

        v =  Mathf.RoundToInt(transform.position.y/5 * Random.value);
        for (int i = 0; i < v; i++)
        {
            RaycastHit hit;
            if (Physics.Raycast(zero + new Vector3(Random.value * x, 1, Random.value * z), Vector3.down, out hit, 1.4f))
            {
                GameObject b = Instantiate(bee, transform);
                bees.Add(b);

                b.transform.position = hit.point+Vector3.up;

            }
        }

    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
